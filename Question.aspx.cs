using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Question : System.Web.UI.Page
{
    protected System.Web.UI.WebControls.Button SubmitButton;
    protected string[] AnswerArray=new string[100];
    protected string[] TesterArray = new string[100];
    protected string[] WrongArray = new string[100];
    protected bool[] CorrectArray = new bool[100];
    protected int NumberOfQuestions = 0;
    protected int NumberCorrect = 0;
    protected int NumberWrong = 0;
    protected string QuizTitle = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ReadQuizTitle();
            ReadQuestionsIntoTable();
            AddSubmitButton();
        }
        else
        {
            HttpRequest r;
            r = this.Request;
            bool AreAllAnswered= CalculateScore(r);

            HttpResponse rs;
            rs = this.Response;
            if(AreAllAnswered==false)
            {
                rs.Write("You missed some questions.Please go back in your browser and answer them <p>");
                return;
            }
            rs.Write("Your score is "+NumberCorrect.ToString()+"out of"+NumberOfQuestions.ToString()+ "<p>");
            for(int num=0;num<NumberOfQuestions;num++)
            {
                if (WrongArray[num].Length>0) rs.Write(WrongArray[num]);
            }
            rs.Write(GetRanking());
        }
    }
    private void InitializeComponent()
    {
    }
    protected void page_Init(object sender, EventArgs e)
    {
        InitializeComponent();
    }
    public Question()
    {
        Page.Init += new System.EventHandler(page_Init);
    }
    private void ReadQuizTitle()
    {
        IEnumerable collection = SelectRows("Select Choices from Questions");
        foreach (DataRowView viewRow in collection)
        {
            QuizTitle = (string)viewRow.Row["Choices"];
        }
        TableRow tr = new TableRow();
        Table1.Rows.Add(tr);
        TableCell aCell = new TableCell();
        aCell.Text = "<H1><font color=\"blue\">" + QuizTitle + "</font></H1>\n";
        tr.Cells.Add(aCell);

    }
    private IEnumerable SelectRows(string queryString)
    {
        DataSourceSelectArguments args = new DataSourceSelectArguments("");
        SqlDataSource1.SelectCommand = queryString;
        return SqlDataSource1.Select(args);
    }
    object GetColumnValue(string queryString, string columnName)
    {
        DataSourceSelectArguments args = new DataSourceSelectArguments("");
        SqlDataSource1.SelectCommand = queryString;
        IEnumerator enumerator = SqlDataSource1.Select(args).GetEnumerator();
        enumerator.MoveNext();
        return ((DataRowView)enumerator.Current)[columnName];
    }
    private void ReadQuestionsIntoTable()
    {
        NumberOfQuestions = 0;
        IEnumerable questions = SelectRows("select * from Questions");
        foreach (DataRowView question in questions)
        {
            TableRow tr = new TableRow();
            Table1.Rows.Add(tr);
            TableCell aCell = new TableCell();
            aCell.Text = question["QuestionText"].ToString();
            tr.Cells.Add(aCell);
            string questionNumber = String.Format("Answer{0}", question["QuestionID"].ToString());
            Session[questionNumber] = question["Answer"].ToString();

            int count = 0;
            TableRow blankRow = new TableRow();
            TableCell cellPad = new TableCell();
            cellPad.BorderWidth = 5;
            blankRow.Cells.Add(cellPad);
            Table1.Rows.Add(blankRow);
            IEnumerable choices = SelectRows(String.Format("Select * from Choices where QuestionID={0}", question["QuestionID"]));
            foreach (DataRowView choiceRow in choices)
            {
                TableRow tr2 = new TableRow();
                Table1.Rows.Add(tr2);
                TableCell aCell3 = new TableCell();
                aCell3.Width = 1000;
                aCell3.HorizontalAlign = HorizontalAlign.Left;
                tr2.Cells.Add(aCell3);
                RadioButton rb = new RadioButton();
                rb.GroupName = "Group" + choiceRow["QuestionID"].ToString();
                rb.Text = choiceRow["choiceLetter"].ToString() + ". " + choiceRow["choiceText"].ToString();
                rb.ID = "Radio" + NumberOfQuestions.ToString() + Convert.ToChar(count + 65);
                rb.Visible = true;
                aCell3.Controls.Add(rb);
                count++;
            }
            TableRow spacer = new TableRow();
            TableCell spacerCell = new TableCell();
            spacerCell.Height = 30;
            spacer.Cells.Add(spacerCell);
            Table1.Rows.Add(spacer);

            NumberOfQuestions++;
        
        }
    }
    private void AddSubmitButton()
    {
        SubmitButton = new Button();
        this.Controls.Add(SubmitButton);
        this.SubmitButton.Click += new System.EventHandler(this.Button1_Click);
        SubmitButton.Width = 100;
        SubmitButton.Height = 25;
        SubmitButton.Visible = true;
        SubmitButton.Text = "Score";
        SubmitButton.Style.Add("runat", "server");
        TableRow ButtonRow = new TableRow();
        TableCell ButtonCell = new TableCell();
        ButtonRow.Cells.Add(ButtonCell);
        ButtonCell.Controls.Add(SubmitButton);
        Table1.Rows.Add(ButtonRow);
        //Response.Redirect("Payments.aspx");
    }
    private int CalcQuestionsAnsweredCount(HttpRequest r)
    {
        int count = 0;
        for (int i = 0; i < r.Form.Keys.Count; i++)
        {
            string nextKey = r.Form.Keys[i];
            if (nextKey.Substring(0, 5) == "Group")
            {
                count++;
            }
        } 
        return count;
    }
    private bool CalculateScore(HttpRequest r)
    {
        // initialize wrong answer array
        WrongArray.Initialize();

        // Load up statistic table to get Number of Questions
        NumberOfQuestions = (int)GetColumnValue("Select * from StatsTable", "NumberOfQuestions");
        // make sure all questions were answered by the tester
        int numAnswered = CalcQuestionsAnsweredCount(r);
        if (numAnswered != NumberOfQuestions)
        {
            return false;
        }


        NumberCorrect = 0;
        NumberWrong = 0;

        // initialize wrong answer array to empty string
        for (int j = 0; j < NumberOfQuestions; j++)
        {
            WrongArray[j] = "";
        }

        // cycle through all the keys in the returned Request
        for (int i = 0; i < r.Form.Keys.Count; i++)
        {
            string nextKey = r.Form.Keys[i];

            // see if the key contains a radio button Group
            if (nextKey.Substring(0, 5) == "Group")
            {
                // It contains a radiobutton, get the radiobutton ID
                string radioAnswer = r.Form.Get(nextKey);

                // extract the letter choice of the tester from the button ID
                string radioAnswerLetter = radioAnswer[radioAnswer.Length - 1].ToString();

                // extract the question number from the radio ID
                string radioQuestionNumber = radioAnswer.Substring(5);
                radioQuestionNumber = radioQuestionNumber.Substring(0, radioQuestionNumber.Length - 1);
                int questionNumber = Convert.ToInt32(radioQuestionNumber, 10) + 1;

                // now compare the testers answer to the answer in the database
                string correctAnswer = (string)Session[String.Format("Answer{0}", questionNumber)];
                if (radioAnswerLetter == correctAnswer)
                {
                    // tester got it right, increment the # correct
                    NumberCorrect++;
                    CorrectArray[questionNumber - 1] = true;
                    WrongArray[questionNumber - 1] = "";
                }
                else
                {
                    // tester got it wrong, increment the # incorrect
                    CorrectArray[questionNumber - 1] = false;

                    // look up the correct answer

                    // put the correct answer in the Wrong Answer Array.
                    WrongArray[questionNumber - 1] = "Question #" + questionNumber + " - <B>" + radioAnswerLetter + "</B>. " + correctAnswer + "<BR>\n";

                    // increment the # of wrong answers
                    NumberWrong++;
                }
            }
        }

        return true;
    }
    private string GetRanking()
    {
        float ratio = (float)NumberCorrect / (float)NumberOfQuestions;
        if (ratio >= 0.99)
            return "<p> Excellent, your score is 100";
        if (ratio >= 0.89)
            return "<p> very good, your score is 90";
        if (ratio >= 0.79)
            return "<p> good, your score is 80";
        if (ratio >= 0.69)
            return "<p> satisfy, your score is 70";
        if (ratio >= 0.59)
            return "<p> Poor, your score is 60";
        if (ratio >= 0.49)
            return "<p> Bad, your score is 50. you are fail.";
        if (ratio >= 0.39)
            return "<p> very Bad, your score is 40.you are fail.";
        if (ratio >= 0.29)
            return "<p> very Bad, your score is 30.you are fail.";
        if (ratio >= 0.19)
            return "<p> very Bad, your score is 20.you are fail.";

        if (ratio >= 0.09)
            return "<p> very Bad, your score is 10.you are fail.";
        if (ratio > 0.001)
            return "<p><I> Random chance</I> got few, but you may want to brush up";
        return "<P> you may want to brush up";
    }
    private void Button1_Click(object sender, System.EventArgs e)
    {

    }

   protected void Submit(object sender, EventArgs e)
    {

    }
}
