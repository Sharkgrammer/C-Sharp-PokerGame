using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace PokerGameV2
{
    public partial class frmMain : Form
    {
        MySqlConnection Connect;
        List<int> PlayerCards = new List<int>();
        List<int> GameCards = new List<int>();
        List<int> PlayerDatabaseInfo = new List<int>();
        List<int> GameDatabaseInfo = new List<int>();
        List<Bitmap> AllCards = new List<Bitmap> ();
        Boolean Ready = false; int TempVar = 0;

        public frmMain()
        {
            InitializeComponent();
            StartUp();
            Connect = AccessDatabase();
          //  Connect = null; 
            if (Connect == null)
            {
               // Bleh();
               // MessageBox.Show("database accessed");
            /*    CreatePlayerDatabase();
                RefreshDatabase(1);
                RefeshScreenShit();
                RefreshTimer.Enabled = true;
                btnCards.Enabled = false;
                this.Text = "Player: " + PlayerDatabaseInfo[0];*/
            }
            else
            {
             //   Bleh();
                MessageBox.Show("Boop");
                /*      RandomCards(2);
                GameCards[0] = 15;
                GameCards[1] = 16;
                GameCards[2] = 100;
                GameCards[3] = 100;
                GameCards[4] = 17;
                MessageBox.Show(Hand(18, 19, 0).ToString());*/
            }
        }

        public void DefaultCards(int Type)
        {
            CardData();
            if (Type == 0)
            {
                pcbPlayer1.Image = AllCards[0];
                pcbPlayer2.Image = AllCards[0];
            }
            pcbGame1.Image = AllCards[0];
            pcbGame2.Image = AllCards[0];
            pcbGame3.Image = AllCards[0];
            pcbGame4.Image = AllCards[0];
            pcbGame5.Image = AllCards[0];
        }

        public void StartUp()
        {
            ReadyLists();
            DefaultCards(1);
            RefeshScreenShit();
            
        }

        void RefeshScreenShit()
        {
            lblHighestBet.Text = "Highest Bet: " + CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol + GameDatabaseInfo[3];
            lblPotMoney.Text = "Pot Money: " + CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol + GameDatabaseInfo[2];
            lblUserMoney.Text = "User Money: " + CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol + PlayerDatabaseInfo[1];
            lblYourBet.Text = "Your Bet: " + CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol + PlayerDatabaseInfo[2];
        }

        void RandomCards(int Type) //0 = game, 1 = player, 2 = both
        {
            Random Rand = new Random();
            int Temp = 0;
            Boolean Pass = true;
            if (Type == 0 || Type == 2)
            {
                for (int i = 0; i < 6; i++)
                {
PassResetLineGame:
                    Temp = Rand.Next(1, 52);
                    if (GameCards.Count != 0)
                    {
                        for (int pi = 0; pi < GameCards.Count; pi++)
                        {
                            if (Temp == GameCards[pi])
                            {
                                Pass = false;
                            }
                        }
                        if (Pass)
                        {
                            GameCards[i] = Temp;
                        }
                        else
                        {
                            Pass = true;
                            goto PassResetLineGame;
                        }
                    }else
                    {
                        GameCards[i] = Temp;
                    }
                }
                String Query = "Update GameDatabase set Card1 = " + GameCards[0] + ", Card2 = " + GameCards[1] + ", Card3 = " + GameCards[2] + ", Card4 = " + GameCards[3] + ", Card5 = " + GameCards[4] + ";";
                MySqlCommand Command = new MySqlCommand(Query, Connect);
                Command.ExecuteScalar();
            }
            if (Type == 1 || Type == 2)
            {
                List<int> list = new List<int>();
                String Query = "select Card1, Card2 from PlayerDatabase";
                MySqlCommand Command = new MySqlCommand(Query, Connect);
                int Count;
                MySqlDataReader data_reader = Command.ExecuteReader();
                if (data_reader.HasRows)
                {
                    Count = data_reader.FieldCount;
                    while (data_reader.Read())
                    {
                        for (var i = 0; i < Count; i++)
                        {
                            list.Add(Convert.ToInt32(data_reader.GetValue(i)));
                        }
                    }
                    data_reader.Close();
                }
                Query = "select Card1, Card2, Card3, Card4, Card5 from GameDatabase";
                Command = new MySqlCommand(Query, Connect);
                Count = 0;
                data_reader = Command.ExecuteReader();
                if (data_reader.HasRows)
                {
                    Count = data_reader.FieldCount;
                    while (data_reader.Read())
                    {
                        for (var i = 0; i < Count; i++)
                        {
                            list.Add(Convert.ToInt32(data_reader.GetValue(i)));
                        }
                    }
                    data_reader.Close();
                }
                PlayerCards.Clear();
                for (int i = 0; i < 6; i++)
                {
PassResetLinePlayer:
                    Temp = Rand.Next(1, 52);
                    if (PlayerCards.Count != 0)
                    {
                        for (int pi = 0; pi < PlayerCards.Count; pi++)
                        {
                            if (Temp == PlayerCards[pi])
                            {
                                Pass = false;
                            }
                        }
                       /* for (int pi = 0; pi < GameCards.Count; pi++)
                        {
                            if (Temp == GameCards[pi])
                            {
                                Pass = false;
                            }
                        }*/
                        for (int pi = 0; pi < list.Count; pi++)
                        {
                            if (Temp == list[pi])
                            {
                                Pass = false;
                            }
                        }
                        if (Pass)
                        {
                            PlayerCards.Add(Temp);
                        }
                        else
                        {
                            Pass = true;
                            goto PassResetLinePlayer;
                        }
                    }
                    else
                    {
                        for (int pi = 0; pi < GameCards.Count; pi++)
                        {
                            if (Temp == GameCards[pi])
                            {
                                Pass = false;
                            }
                        }
                        for (int pi = 0; pi < list.Count; pi++)
                        {
                            if (Temp == list[pi])
                            {
                                Pass = false;
                            }
                        }
                        if (Pass)
                        {
                            PlayerCards.Add(Temp);
                        }
                        else
                        {
                            Pass = true;
                            goto PassResetLinePlayer;
                        }
                    }
                }
                data_reader.Close();
                Query = "Update PlayerDatabase set Card1 = " + PlayerCards[0] + ", Card2 = " + PlayerCards[1] + " where PlayerNo = " + PlayerDatabaseInfo[0] + ";";
                Command = new MySqlCommand(Query, Connect);
                Command.ExecuteScalar();
            } 
        }

        private void btnCards_Click(object sender, EventArgs e)
        { 
            if (Ready)
            {
                btnCards.Enabled = true;
                if (pcbPlayer1.Image == AllCards[0])
                {
                    pcbPlayer1.Image = AllCards[PlayerCards[0]];
                    pcbPlayer2.Image = AllCards[PlayerCards[1]];
                }
                else
                {
                    pcbPlayer1.Image = AllCards[0];
                    pcbPlayer2.Image = AllCards[0];
                }
            }
            else
            {
                btnCards.Enabled = false;
            }
        }

        private void btnCallCheck_Click(object sender, EventArgs e)
        {
            if (Ready)
            {
                if (btnCallCheck.Text == "Call")
                {
                    Call();
                }
                else
                {
                    Check();
                }
            }
        }

        private void btnBet_Click(object sender, EventArgs e)
        {
             if (Ready)
              {
                  Bet();
              }
        }

        private void btnFold_Click(object sender, EventArgs e)
        {
            if (Ready)
            {
                Fold();
            }
        }

        void Call()
        {
            if (GameDatabaseInfo[3] > PlayerDatabaseInfo[1]) //HighestBet > UserMoney
            {
                MessageBox.Show("Not enough money!");
            }
            else
            {
                PlayerDatabaseInfo[1] = PlayerDatabaseInfo[1] - GameDatabaseInfo[3];
                PlayerDatabaseInfo[2] = GameDatabaseInfo[3];
                PlayerDatabaseInfo[3] = 2;
                GameDatabaseInfo[2] += PlayerDatabaseInfo[2];
                UpdateDatabase(0);
            }
        }

        void Bet()
        {
            RefreshTimer.Enabled = false;
            try
            {
                int input = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("How much do you want to bet?\nYou have " + CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol + PlayerDatabaseInfo[1] + " left\nHighest Bet is " + CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol + GameDatabaseInfo[3], "Alert", "", -1, -1));
                if (input > PlayerDatabaseInfo[1]) //input > UserMoney
                {
                    MessageBox.Show("Not enough money!");
                }
                else
                {
                    if (input < GameDatabaseInfo[3]) //input > HighestBet
                    {
                        MessageBox.Show("Not bigger then highest bet!");
                    }
                    else
                    {
                        PlayerDatabaseInfo[2] = input;
                        PlayerDatabaseInfo[1] = PlayerDatabaseInfo[1] - PlayerDatabaseInfo[2];
                        PlayerDatabaseInfo[3] = 4;
                        GameDatabaseInfo[3] = PlayerDatabaseInfo[2];
                        GameDatabaseInfo[2] += PlayerDatabaseInfo[2];
                        UpdateDatabase(0);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error in betting");
            }
            RefreshTimer.Enabled = true;
        }

        void CheckOrCall()
        {
            String Query = "select ChoiceMade from PlayerDatabase;";
            MySqlCommand Command = new MySqlCommand(Query, Connect);
            List<int> list = new List<int>();
            int Count;
            MySqlDataReader data_reader = Command.ExecuteReader();
            if (data_reader.HasRows)
            {
                Count = data_reader.FieldCount;
                while (data_reader.Read())
                {
                    for (var i = 0; i < Count; i++)
                    {
                        list.Add(Convert.ToInt32(data_reader.GetValue(i)));
                    }
                }
                data_reader.Close();
            }
            if ((list.Contains(0) || list.Contains(1)) && GameDatabaseInfo[3] == 0)
            {
                btnCallCheck.Text = "Check";
            }
            else
            {
                btnCallCheck.Text = "Call";
            }
        }

        void Check()
        {
            PlayerDatabaseInfo[3] = 1;
            UpdateDatabase(0);
        }

        void Fold()
        {
            DialogResult dialogResult = MessageBox.Show("You sure you want to fold?", "Alert", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (pcbPlayer1.Image == AllCards[0])
                {
                    pcbPlayer1.Image = AllCards[PlayerCards[0]];
                    pcbPlayer2.Image = AllCards[PlayerCards[1]];
                }
                btnFold.Enabled = false;
                btnBet.Enabled = false;
                btnCallCheck.Enabled = false;
                btnCards.Enabled = false;
                PlayerDatabaseInfo[3] = 3;
                UpdateDatabase(0);
            }
        }

        void ResetInterface()
        {
            btnFold.Enabled = true;
            btnBet.Enabled = true;
            btnCallCheck.Enabled = true;
            btnCards.Enabled = true;
            pcbPlayer1.Image = AllCards[0];
            pcbPlayer2.Image = AllCards[0];
        }

        private void btnReady_Click(object sender, EventArgs e)
        {
            Ready = true;
            btnReady.Visible = false;
            btnCards.Enabled = true;
            RandomCards(1);
            DefaultCards(0);
        }

        void CardData()
        {
            //Add all cards to AllCards
            AllCards.Add(Properties.Resources.card_back);
            //Hearts
            AllCards.Add(Properties.Resources.ace_of_hearts);
            AllCards.Add(Properties.Resources._2_of_hearts);
            AllCards.Add(Properties.Resources._3_of_hearts);
            AllCards.Add(Properties.Resources._4_of_hearts);
            AllCards.Add(Properties.Resources._5_of_hearts);
            AllCards.Add(Properties.Resources._6_of_hearts);
            AllCards.Add(Properties.Resources._7_of_hearts);
            AllCards.Add(Properties.Resources._8_of_hearts);
            AllCards.Add(Properties.Resources._9_of_hearts);
            AllCards.Add(Properties.Resources._10_of_hearts);
            AllCards.Add(Properties.Resources.jack_of_hearts2);
            AllCards.Add(Properties.Resources.queen_of_hearts2);
            AllCards.Add(Properties.Resources.king_of_hearts2);
            //Diamonds
            AllCards.Add(Properties.Resources.ace_of_diamonds);
            AllCards.Add(Properties.Resources._2_of_diamonds);
            AllCards.Add(Properties.Resources._3_of_diamonds);
            AllCards.Add(Properties.Resources._4_of_diamonds);
            AllCards.Add(Properties.Resources._5_of_diamonds);
            AllCards.Add(Properties.Resources._6_of_diamonds);
            AllCards.Add(Properties.Resources._7_of_diamonds);
            AllCards.Add(Properties.Resources._8_of_diamonds);
            AllCards.Add(Properties.Resources._9_of_diamonds);
            AllCards.Add(Properties.Resources._10_of_diamonds);
            AllCards.Add(Properties.Resources.jack_of_diamonds2);
            AllCards.Add(Properties.Resources.queen_of_diamonds2);
            AllCards.Add(Properties.Resources.king_of_diamonds2);
            //Clubs
            AllCards.Add(Properties.Resources.ace_of_clubs);
            AllCards.Add(Properties.Resources._2_of_clubs);
            AllCards.Add(Properties.Resources._3_of_clubs);
            AllCards.Add(Properties.Resources._4_of_clubs);
            AllCards.Add(Properties.Resources._5_of_clubs);
            AllCards.Add(Properties.Resources._6_of_clubs);
            AllCards.Add(Properties.Resources._7_of_clubs);
            AllCards.Add(Properties.Resources._8_of_clubs);
            AllCards.Add(Properties.Resources._9_of_clubs);
            AllCards.Add(Properties.Resources._10_of_clubs);
            AllCards.Add(Properties.Resources.jack_of_clubs2);
            AllCards.Add(Properties.Resources.queen_of_clubs2);
            AllCards.Add(Properties.Resources.king_of_clubs2);
            //Spades
            AllCards.Add(Properties.Resources.ace_of_spades);
            AllCards.Add(Properties.Resources._2_of_spades);
            AllCards.Add(Properties.Resources._3_of_spades);
            AllCards.Add(Properties.Resources._4_of_spades);
            AllCards.Add(Properties.Resources._5_of_spades);
            AllCards.Add(Properties.Resources._6_of_spades);
            AllCards.Add(Properties.Resources._7_of_spades);
            AllCards.Add(Properties.Resources._8_of_spades);
            AllCards.Add(Properties.Resources._9_of_spades);
            AllCards.Add(Properties.Resources._10_of_spades);
            AllCards.Add(Properties.Resources.jack_of_spades2);
            AllCards.Add(Properties.Resources.queen_of_spades2);
            AllCards.Add(Properties.Resources.king_of_spades2);
            //Done
        }

        void NextCards()
        {
            if(pcbGame1.Image == AllCards[0])
            {
                pcbGame1.Image = AllCards[GameCards[0]];
                pcbGame2.Image = AllCards[GameCards[1]];
                pcbGame3.Image = AllCards[GameCards[2]];
            }else if(pcbGame4.Image == AllCards[0])
            {
                pcbGame4.Image = AllCards[GameCards[3]];
            }
            else if(pcbGame5.Image == AllCards[0])
            {
                pcbGame5.Image = AllCards[GameCards[4]];
            }
            else
            {
                DefaultCards(0);
                StartUp();
                NextRound();
            }
        }

        MySqlConnection AccessDatabase()
        {
            string connetionString = null;
            connetionString = "SERVER=mysql5.gear.host;DATABASE=apptestdatabase;UID=apptestdatabase;PWD=Lk3AsY-vB_HI;";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            try
            {
                cnn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, cannot connect to database\n" + ex);
                return null;
            }
            return cnn;
        }

        void CreateGameDatabase()
        {
            //Bleh();
            RandomCards(0);
            String Query = @"Insert into GameDatabase(NumbOfPlayers, Winner, SelectedPlayer, Pot, HighestBet, Card1, Card2, Card3, Card4, Card5, Mode) values (
                        0, 
                        0, 
                        1, 
                        0, 
                        0, 
                        " + GameCards[0] + @", 
                        " + GameCards[1] + @", 
                        " + GameCards[2] + @", 
                        " + GameCards[3] + @", 
                        " + GameCards[4] + @",
                        0);";
            MySqlCommand Command = new MySqlCommand(Query, Connect);
            Command.ExecuteScalar();
            CreatePlayerDatabase();
        }

        void CreatePlayerDatabase()
        {
            String Query = "Select NumbOfPlayers from GameDatabase";
            MySqlCommand Command = new MySqlCommand(Query, Connect);
            PlayerDatabaseInfo[0] = (Convert.ToInt16(Command.ExecuteScalar()) + 1);
            if (PlayerDatabaseInfo[0] == 1 && TempVar == 0)
            {
                TempVar++;
                CreateGameDatabase();
            }
            else {
                Query = "Update GameDatabase set NumbOfPlayers = " + (PlayerDatabaseInfo[0]) + ";";
                Command = new MySqlCommand(Query, Connect);
                Command.ExecuteScalar();
                Query = @"Insert into PlayerDatabase (Card1, Card2, ChoiceMade, PlayerNo, UserMoney, UserBet) values(
                        0, 
                        0,
                        0,
                        " + PlayerDatabaseInfo[0] + @",
                        100,
                        0);";
                Command = new MySqlCommand(Query, Connect);
                Command.ExecuteScalar();
                RandomCards(1);
            }
        }

        void RefreshDatabase(int Type)
        {
            if (Type == 0)
            {
                String Query = "select NumbOfPlayers, SelectedPlayer, Pot, HighestBet, Mode from GameDatabase;";
                MySqlCommand Command = new MySqlCommand(Query, Connect);
                int[] SpecialArray = new int[3];
                List<int> list = new List<int>();
                int Count;
                MySqlDataReader data_reader = Command.ExecuteReader();
                if (data_reader.HasRows)
                {
                    Count = data_reader.FieldCount;
                    while (data_reader.Read()) 
                    {
                        for (var i = 0; i < Count; i++)
                        {
                            list.Add(Convert.ToInt32(data_reader.GetValue(i)));
                        }
                    }
                    data_reader.Close();
                }
                GameDatabaseInfo[0] = list[0];
                GameDatabaseInfo[1] = list[1];
                GameDatabaseInfo[2] = list[2]; 
                if (list[3] == 0 || list[3] >= GameDatabaseInfo[3])
                {
                    GameDatabaseInfo[3] = list[3];
                }
                GameDatabaseInfo[4] = list[4];
                RefeshScreenShit();
                /* Query = "select UserMoney, UserBet, ChoiceMade, Card1, Card2 from PlayerDatabase where PlayerNo = " + PlayerDatabaseInfo[0] + ";";
                 Command = new MySqlCommand(Query, Connect);
                 Count = 0;
                 list.Clear();
                 data_reader = Command.ExecuteReader();
                 if (data_reader.HasRows)
                 {
                     Count = data_reader.FieldCount;
                     while (data_reader.Read()) ;
                     {
                         for (var i = 0; i < Count; i++)
                         {
                             list.Add(Convert.ToInt32(data_reader.GetValue(i)));
                         }
                     }
                     data_reader.Close();
                 }
                 PlayerDatabaseInfo[1] = list[0];
                 PlayerDatabaseInfo[2] = list[1];
                 PlayerDatabaseInfo[3] = list[2];
                 PlayerDatabaseInfo[4] = list[3];
                 PlayerDatabaseInfo[5] = list[4];*/
            }
            else
            {
                String Query = "select NumbOfPlayers, SelectedPlayer, Pot, HighestBet from GameDatabase;";
                MySqlCommand Command = new MySqlCommand(Query, Connect);
                int[] SpecialArray = new int[3];
                List<int> list = new List<int>();
                int Count = 0;
                MySqlDataReader data_reader = Command.ExecuteReader();
                if (data_reader.HasRows)
                {
                    Count = data_reader.FieldCount;
                    while (data_reader.Read()) 
                    {
                        for (var i = 0; i < Count; i++)
                        {
                            list.Add(Convert.ToInt32(data_reader.GetValue(i)));
                        }
                    }
                    data_reader.Close();
                }
                GameDatabaseInfo[0] = list[0];
                GameDatabaseInfo[1] = list[1];
                GameDatabaseInfo[2] = list[2];
                GameDatabaseInfo[3] = list[3];
                Query = "select UserMoney, UserBet, ChoiceMade, Card1, Card2 from PlayerDatabase where PlayerNo = " + PlayerDatabaseInfo[0] + ";";
                                 Command = new MySqlCommand(Query, Connect);
                                 Count = 0;
                                 list.Clear();
                                 data_reader = Command.ExecuteReader();
                                 if (data_reader.HasRows)
                                 {
                                     Count = data_reader.FieldCount;
                                     while (data_reader.Read())
                                     {
                                         for (var i = 0; i < Count; i++)
                                         {
                                             list.Add(Convert.ToInt32(data_reader.GetValue(i)));
                                         }
                                     }
                                     data_reader.Close();
                                 }
                                 PlayerDatabaseInfo[1] = list[0];
                                 PlayerDatabaseInfo[2] = list[1];
                                 PlayerDatabaseInfo[3] = list[2];
                                 PlayerDatabaseInfo[4] = list[3];
                                 PlayerDatabaseInfo[5] = list[4];
                Query = "select Card1, Card2, Card3, Card4, Card5 from GameDatabase;";
                Command = new MySqlCommand(Query, Connect);
                Count = 0;
                list.Clear();
                data_reader = Command.ExecuteReader();
                if (data_reader.HasRows)
                {
                    Count = data_reader.FieldCount;
                    while (data_reader.Read())
                    {
                        for (var i = 0; i < Count; i++)
                        {
                            list.Add(Convert.ToInt32(data_reader.GetValue(i)));
                        }
                    }
                    data_reader.Close();
                }
                GameCards[0] = list[0];
                GameCards[1] = list[1];
                GameCards[2] = list[2];
                GameCards[3] = list[3];
                GameCards[4] = list[4];
            }
        }

        void CheckIfNextRoundSomethingSomething()
        {
            RefreshTimer.Enabled = false;
            String Query = "select UserBet, ChoiceMade from PlayerDatabase;";
            MySqlCommand Command = new MySqlCommand(Query, Connect);
            List<int> list = new List<int>();
            int Count;
            MySqlDataReader data_reader = Command.ExecuteReader();
            if (data_reader.HasRows)
            {
                Count = data_reader.FieldCount;
                while (data_reader.Read())
                {
                    for (var i = 0; i < Count; i++)
                    {
                        list.Add(Convert.ToInt32(data_reader.GetValue(i)));
                    }
                }
                data_reader.Close();
            }
            Boolean Pass = true;
            for (int i = 0; i < list.Count(); i += 2)
            {
                if (list[i] == GameDatabaseInfo[3] && GameDatabaseInfo[3] != 0)
                {
                    continue;
                }
                else if (list[i + 1] == 3 || list[i + 1] == 1)
                {
                    continue;
                }
                Pass = false;
            }
            if (Pass)
            {
                Query = "select Pot from GameDatabase;";
                Command = new MySqlCommand(Query, Connect);
                if (Convert.ToInt16(Command.ExecuteScalar()) != GameDatabaseInfo[2])
                {
                    Query = "Update GameDatabase set Pot = " + GameDatabaseInfo[2] + ";";
                    Command = new MySqlCommand(Query, Connect);
                    Command.ExecuteScalar();
                }
                System.Threading.Thread.Sleep(200);
                if (PlayerDatabaseInfo[0] != 1)
                {
                    while(GameDatabaseInfo[3] != 0)
                    {
                        System.Threading.Thread.Sleep(50);
                        RefreshDatabase(0);
                    }
                    if (PlayerDatabaseInfo[3] == 1)
                    {
FuckThisLine:
                        System.Threading.Thread.Sleep(50);
                        Query = "select ChoiceMade from PlayerDatabase;";
                        Command = new MySqlCommand(Query, Connect);
                        List<int> list2 = new List<int>();
                        data_reader = Command.ExecuteReader();
                        if (data_reader.HasRows)
                        {
                            Count = data_reader.FieldCount;
                            while (data_reader.Read())
                            {
                                for (var i = 0; i < Count; i++)
                                {
                                    list2.Add(Convert.ToInt32(data_reader.GetValue(i)));
                                }
                            }
                            data_reader.Close();
                        }
                        if (!list2.Contains(0))
                        {
                            goto FuckThisLine;
                        }
                    }
                    if (PlayerDatabaseInfo[3] != 3)
                    {
                        PlayerDatabaseInfo[3] = 0;
                    }
                    PlayerDatabaseInfo[2] = 0;
                    UpdateDatabase(2);
                }
                else
                {
                    System.Threading.Thread.Sleep(500);
                    GameDatabaseInfo[3] = 0;
                    PlayerDatabaseInfo[3] = 0;
                    PlayerDatabaseInfo[2] = 0;
                    UpdateDatabase(2);
                    RefreshDatabase(0);
                }
                NextCards();
            }
            RefreshTimer.Enabled = true;
        }

        void UpdateDatabase(int Type) //NextPlayerCode
        {
            String Query = "Update PlayerDatabase set ChoiceMade = " + PlayerDatabaseInfo[3] + ", UserMoney = " + PlayerDatabaseInfo[1] + ", UserBet = " + PlayerDatabaseInfo[2] + " where PlayerNo = " + PlayerDatabaseInfo[0] + ";";
            MySqlCommand Command = new MySqlCommand(Query, Connect);
            Command.ExecuteNonQuery();
            Query = "Update GameDatabase set HighestBet = " + GameDatabaseInfo[3] + ",Pot = " + GameDatabaseInfo[2] + ";";
            Command = new MySqlCommand(Query, Connect);
            Command.ExecuteNonQuery();
            if (Type != 2)
            {
                if (PlayerDatabaseInfo[0] == GameDatabaseInfo[0])
                {
                    Query = "Update GameDatabase set SelectedPlayer = 1;";
                    Command = new MySqlCommand(Query, Connect);
                    Command.ExecuteScalar();
                }
                else
                {
                    Query = "Update GameDatabase set SelectedPlayer = " + (GameDatabaseInfo[1] + 1) + ";";
                    Command = new MySqlCommand(Query, Connect);
                    Command.ExecuteScalar();
                }
            }
            RefeshScreenShit();
            RefreshDatabase(0);
        }

        void Bleh()
        {
            try
            {
                String Temp = "DROP TABLE GameDatabase";
                MySqlCommand Commandz = new MySqlCommand(Temp, Connect);
                Commandz.ExecuteNonQuery();
            }
            catch
            {
                //bleh
            }
            try
            {
                String Temp = "DROP TABLE PlayerDatabase";
                MySqlCommand Commandz = new MySqlCommand(Temp, Connect);
                Commandz.ExecuteNonQuery();
            }
            catch
            {
                //bleh
            }
            String Query = @"Create Table GameDatabase(
                            NumbOfPlayers varchar(20),
                            Winner varchar(20),
                            SelectedPlayer varchar(20),
                            Pot varchar(20),
                            HighestBet varchar(20),
                            Mode varchar(20),
                            Card1 varchar(20),
                            Card2 varchar(20),
                            Card3 varchar(20),
                            Card4 varchar(20),
                            Card5 varchar(20));";
            MySqlCommand Command = new MySqlCommand(Query, Connect);
            Command.ExecuteScalar();
            Query = @"Create Table PlayerDatabase (
                             Card1 varchar(20),
                             Card2 varchar(20),
                             ChoiceMade varchar(20),
                             PlayerNo varchar(20),
                             UserMoney varchar(20),
                             UserBet varchar(20));";
            Command = new MySqlCommand(Query, Connect);
            Command.ExecuteScalar();
        }

        void ReadyLists()
        { 
            for (int i = 0; i < 7; i++)
            {
                PlayerDatabaseInfo.Add(0);
            }
            for (int i = 0; i < 10; i++)
            {
                GameDatabaseInfo.Add(0);
            }
            for (int i = 0; i < 8; i++)
            {
                GameCards.Add(0);
            }
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            if (PlayerDatabaseInfo[3] != 3)
            {
                if (GameDatabaseInfo[1] == PlayerDatabaseInfo[0])
                {
                    btnFold.Enabled = true;
                    btnBet.Enabled = true;
                    btnCallCheck.Enabled = true;
                 //   btnCards.Enabled = true;
                }
                else
                {
                    CheckIfNextRoundSomethingSomething();
                    btnFold.Enabled = false;
                    btnBet.Enabled = false;
                    btnCallCheck.Enabled = false;
                   // btnCards.Enabled = false;
                }
                RefreshDatabase(0);
                CheckOrCall();
             }
             else
             {
                if (GameDatabaseInfo[1] == PlayerDatabaseInfo[0])
                {
                    UpdateDatabase(0);
                }
                CheckIfNextRoundSomethingSomething();
                RefreshDatabase(0);
            }
        }

        void NextRound()
        {
            if (PlayerDatabaseInfo[0] == 1)
            {
                RandomCards(2);
            }
            else
            {
                RandomCards(1);
            }
            String Query = "Select Winner from GameDatabase";
            MySqlCommand Command = new MySqlCommand(Query, Connect);
            int Winner = Convert.ToInt32(Command.ExecuteScalar());
            if (Winner == 0)
            {
                if (PlayerDatabaseInfo[0] == 1)
                {
                    Winner = CheckWinner();
                    Query = "Update GameDatabase set Winner = " + Winner + ";";
                    Command = new MySqlCommand(Query, Connect);
                    Command.ExecuteNonQuery();
                    MessageBox.Show(Winner.ToString());
                }
                else
                {
                    while (Winner == 0)
                    {
                        System.Threading.Thread.Sleep(50);
                        Winner = Convert.ToInt32(new MySqlCommand("Select Winner from GameDatabase", Connect).ExecuteScalar());
                    }
                }
            }
            if (Winner == PlayerDatabaseInfo[0])
            {
                PlayerDatabaseInfo[1] += GameDatabaseInfo[2];
                GameDatabaseInfo[1] = 1;
                GameDatabaseInfo[2] = 0;
                GameDatabaseInfo[3] = 0;
                Query = "Update GameDatabase set Winner = 0;";
                Command = new MySqlCommand(Query, Connect);
                Command.ExecuteNonQuery();
            }
            PlayerDatabaseInfo[3] = 0;
            UpdateDatabase(2);
            RefreshDatabase(1);
            btnCards.Enabled = true;
            RefeshScreenShit();
        }

        int CheckWinner()
        {
            int Winner = 0;
            List<int> list = new List<int>();
            List<int> listTwo = new List<int>();
            String Query = "select Card1, Card2 from PlayerDatabase;";
            MySqlCommand Command = new MySqlCommand(Query, Connect);
            int Count;
            MySqlDataReader data_reader = Command.ExecuteReader();
            if (data_reader.HasRows)
            {
                Count = data_reader.FieldCount;
                while (data_reader.Read())
                {
                    for (var i = 0; i < Count; i++)
                    {
                        listTwo.Add(Convert.ToInt32(data_reader.GetValue(i)));
                    }
                }
                data_reader.Close();
            }
            for (int i = 0; i < (GameDatabaseInfo[0] * 2); i += 2)
            {
                list.Add(Hand(listTwo[i], listTwo[i + 1], 0));
                MessageBox.Show(Hand(listTwo[i], listTwo[i + 1], 0).ToString());
            }
            int Max = 0, MaxTemp = 0, Spare = 0, SpareTemp = 0;
            for (int i = 0; i < list.Count(); i++)
            {
                if (Max < list[i])
                {
                    Max = list[i];
                    MaxTemp = i;
                }
                else if (Max == list[i])
                {
                    Spare = list[i];
                    SpareTemp = i;
                }
            }
            if (Max == Spare)
            {
                List<int> listThree = new List<int>();
                List<int> listFour = new List<int>();
                for (int i = 0; i < listTwo.Count(); i++)
                {
                    while(listTwo[i] < 14)
                    {
                        listTwo[i] -= 13;
                    }
                    if (i == (MaxTemp * 2) || i == (MaxTemp * 2) + 1)
                    {
                        listThree.Add(listTwo[i]);
                    }
                    else if (i == (SpareTemp * 2) || i == (SpareTemp * 2) + 1)
                    {
                        listFour.Add(listTwo[i]);
                    }
                }
                if ((listThree[0] + listThree[1]) > listFour[0] + listFour[1])
                {
                    Winner = MaxTemp;
                }
                else
                {
                    Winner = SpareTemp;
                }
            }
            else
            {
                Winner = MaxTemp;
            }
            MessageBox.Show(Winner.ToString());
            return Winner;
        }

        int Hand(int Card1, int Card2, int Type)
        {
            int Hand = 0;
            if (Type == 0)
            {
                List<int> Templist = new List<int>();
                GameCards[5] = Card1;
                GameCards[6] = Card2;
                GameCards.Sort();
                while (Type == 0)
                {
                    //RoyalFlush
                    if (GameCards.Contains(10) && GameCards.Contains(11) && GameCards.Contains(12) && GameCards.Contains(13) && GameCards.Contains(1))
                    {
                        Hand = 1;
                        break;
                    }
                    else if (GameCards.Contains(23) && GameCards.Contains(24) && GameCards.Contains(25) && GameCards.Contains(26) && GameCards.Contains(14))
                    {
                        Hand = 1;
                        break;
                    }
                    else if (GameCards.Contains(36) && GameCards.Contains(37) && GameCards.Contains(38) && GameCards.Contains(39) && GameCards.Contains(27))
                    {
                        Hand = 1;
                        break;
                    }
                    else if (GameCards.Contains(49) && GameCards.Contains(50) && GameCards.Contains(51) && GameCards.Contains(52) && GameCards.Contains(40))
                    {
                        Hand = 1;
                        break;
                    }

                    //Straight Flush
                    int TempThing = 0, Counter = 0, TempCounter = 0, WinCounter = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        if (GameCards[i] + 1 == GameCards[i + 1] && GameCards[i + 1] + 1 == GameCards[i + 2]
                            && GameCards[i + 2] + 1 == GameCards[i + 3] && GameCards[i + 3] + 1 == GameCards[i + 4]
                            && GameCards[i + 4] + 1 == GameCards[i + 5])
                        {
                            for (int pi = 0; pi < GameCards.Count(); i++)
                            {
                                TempThing = GameCards[pi];
                                Counter = 0;
                                while (TempThing > 14)
                                {
                                    TempThing -= 13;
                                    Counter++;
                                }
                                if (Counter == TempCounter)
                                {
                                    if (WinCounter == 5)
                                    {
                                        Hand = 2;
                                        break;
                                    }
                                    WinCounter++;
                                }
                                else
                                {
                                    TempCounter = Counter;
                                }
                            }
                        }
                        if (Hand != 0)
                        {
                            break;
                        }
                    }
                    if (Hand != 0)
                    {
                        break;
                    }

                    //Four Of A kind
                    for (int i = 0; i < 14; i++)
                    {
                        if (GameCards.Contains(i) && GameCards.Contains(i + 13) && GameCards.Contains(i + 26) && GameCards.Contains(i + 39))
                        {
                            Hand = 3;
                            break;
                        }
                    }
                    if (Hand != 0)
                    {
                        break;
                    }

                    //Full House
                    for (int i = 0; i < 14; i++)
                    {
                        if ((GameCards.Contains(i) && GameCards.Contains(i + 13) && GameCards.Contains(i + 26))
                            || (GameCards.Contains(i + 13) && GameCards.Contains(i + 26) && GameCards.Contains(i + 39))
                            || (GameCards.Contains(i) && GameCards.Contains(i + 13) && GameCards.Contains(i + 39))
                            || (GameCards.Contains(i) && GameCards.Contains(i + 26) && GameCards.Contains(i + 39)))
                        {
                            if ((GameCards.Contains(i) && GameCards.Contains(i + 13))
                            || (GameCards.Contains(i) && GameCards.Contains(i + 26))
                            || (GameCards.Contains(i) && GameCards.Contains(i + 39))
                            || (GameCards.Contains(i + 13) && GameCards.Contains(i + 26))
                            || (GameCards.Contains(i + 13) && GameCards.Contains(i + 39))
                            || (GameCards.Contains(i + 26) && GameCards.Contains(i + 39)))
                            {
                                Hand = 4;
                                break;
                            }
                        }
                    }
                    if (Hand != 0)
                    {
                        break;
                    }

                    //Flush
                   /* TempThing = 0; Counter = 0; TempCounter = 0; WinCounter = 0;
                    for (int i = 0; i < GameCards.Count(); i++)
                    {
                        TempThing = GameCards[i];
                        Counter = 0;
                        while (TempThing > 14)
                        {
                            TempThing -= 13;
                            Counter++;
                        }
                        if (Counter == TempCounter)
                        {
                            if (WinCounter == 5)
                            {
                                Hand = 5;
                                break;
                            }
                            WinCounter++;
                        }
                        else
                        {
                            TempCounter = Counter;
                        }
                    }
                    if (Hand != 0)
                    {
                        break;
                    }
                    */

                    //Straight
                    for (int i = 0; i < 3; i++)
                    {
                        if (GameCards[i] + 1 == GameCards[i + 1] && GameCards[i + 1] + 1 == GameCards[i + 2]
                            && GameCards[i + 2] + 1 == GameCards[i + 3] && GameCards[i + 3] + 1 == GameCards[i + 4]
                            && GameCards[i + 4] + 1 == GameCards[i + 5])
                        {
                            Hand = 6;
                            break;
                        }
                    }
                    if (Hand != 0)
                    {
                        break;
                    }

                    //Three Of A Kind
                    for (int i = 0; i < 14; i++)
                    {
                        if ((GameCards.Contains(i) && GameCards.Contains(i + 13) && GameCards.Contains(i + 26))
                           || (GameCards.Contains(i + 13) && GameCards.Contains(i + 26) && GameCards.Contains(i + 39))
                           || (GameCards.Contains(i) && GameCards.Contains(i + 13) && GameCards.Contains(i + 39))
                           || (GameCards.Contains(i) && GameCards.Contains(i + 26) && GameCards.Contains(i + 39)))
                        {
                            Hand = 7;
                            break;
                        }
                    }
                    if (Hand != 0)
                    {
                        break;
                    }

                    //Two Pairs
                    int Counter2 = 0;
                    for (int i = 0; i < 14; i++)
                    {
                        if (GameCards.Contains(i) && GameCards.Contains(i + 13))
                        {
                            Counter2++;
                        }
                        if (GameCards.Contains(i) && GameCards.Contains(i + 26))
                        {
                            Counter2++;
                        }
                        if (GameCards.Contains(i) && GameCards.Contains(i + 39))
                        {
                            Counter2++;
                        }
                        if (GameCards.Contains(i + 13) && GameCards.Contains(i + 26))
                        {
                            Counter2++;
                        }
                        if (GameCards.Contains(i + 13) && GameCards.Contains(i + 39))
                        {
                            Counter2++;
                        }
                        if (GameCards.Contains(i + 26) && GameCards.Contains(i + 39))
                        {
                            Counter2++;
                        }
                        if (Counter2 == 2)
                        {
                            Hand = 8;
                            break;
                        }
                    }
                    if (Hand != 0)
                    {
                        break;
                    }

                    //Pair
                    for (int i = 0; i < 14; i++)
                    {
                        if ((GameCards.Contains(i) && GameCards.Contains(i + 13))
                            || (GameCards.Contains(i) && GameCards.Contains(i + 26))
                            || (GameCards.Contains(i) && GameCards.Contains(i + 39))
                            || (GameCards.Contains(i + 13) && GameCards.Contains(i + 26))
                            || (GameCards.Contains(i + 13) && GameCards.Contains(i + 39))
                            || (GameCards.Contains(i + 26) && GameCards.Contains(i + 39)))
                        {
                            Hand = 9;
                            break;
                        }
                    }
                    if (Hand != 0)
                    {
                        break;
                    }

                    //High Card
                    Hand = 10;
                    break;
                }
            }
            else
            {
                //Type = 2
                Hand = 1;
            }
            return Hand;
        }
    }
}