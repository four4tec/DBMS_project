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

namespace DBMS_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Form1_Load);
            /*
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "127.0.0.1";
            conn_string.UserID = "root";
            conn_string.Password = "shadow232";
            conn_string.Database = "world";
            conn_string.Port = 3306;
            conn_string.SslMode = MySqlSslMode.None;
            MySqlConnection conn = new MySqlConnection(conn_string.ToString());
            MySqlCommand command = conn.CreateCommand();
            conn.Open();

            String account;
            String password;
            int level;
            for (int i = 0; i < 10; i++)
            {
                account = "account" + i.ToString();
                password = "password" + i.ToString();
                level = i * 10;
                command.CommandText = "Insert into member(account,password,level) values('" + account + "','" + password + "'," + level + ")";
                command.ExecuteNonQuery();
            }
            Console.ReadLine();
            conn.Close();*/
        }

        //login
        private Label usr = new Label();
        private Label pwd = new Label();
        private TextBox usr_te1 = new TextBox();
        private TextBox pwd_te1 = new TextBox();
        private Button login_bu = new Button();
        private Button create_bu = new Button();
        private string user_id;
        //main
        private List<item> all = new List<item>();
        private Button sell_bu = new Button();
        private Button hyper_bu = new Button();
        private Button status_bu = new Button();
        private Button return_bu = new Button();
        private ComboBox search_type = new ComboBox();
        private ComboBox type_select1 = new ComboBox();
        private ComboBox type_select2 = new ComboBox();
        private Button select_exe_bu = new Button();
        //hyper
        private TextBox in_te = new TextBox();
        private TextBox out_te = new TextBox();
        private Button hyper_send = new Button();
        //user status
        private Label status_la = new Label();
        private ComboBox select_search_type = new ComboBox();
        private Button status_exe_bu = new Button();
        private Button delete_bu = new Button();
        private void Form1_Load(object sender, EventArgs e) {
            this.Width = 500;
            this.Height = 700;
            //login page
            usr.Location = new Point(140, 150);
            usr.Size = new Size(50, 50);
            usr.Text = "帳號：";
            this.Controls.Add(usr);
            pwd.Location = new Point(140, 220);
            pwd.Size = new Size(50, 50);
            pwd.Text = "密碼：";
            this.Controls.Add(pwd);
            usr_te1.Location = new Point(200, 150);
            usr_te1.Size = new Size(150, 50);
            this.Controls.Add(usr_te1);
            pwd_te1.Location = new Point(200, 220);
            pwd_te1.Size = new Size(150, 50);
            this.Controls.Add(pwd_te1);
            login_bu.Location = new Point(220,290);
            login_bu.Size = new Size(100,50);
            login_bu.Text = "登入";
            this.Controls.Add(login_bu);
            this.login_bu.Click += new System.EventHandler(this.login_bu_cli);
            create_bu.Location = new Point(220,400);
            create_bu.Size = new Size(50,50);
            create_bu.Text = "create\naccount";
            create_bu.Click += new System.EventHandler(this.create_cli);
            this.Controls.Add(create_bu);
            //main
            sell_bu.Location = new Point(50,50);
            sell_bu.Size = new Size(50,30);
            sell_bu.Text = "sell item";
            sell_bu.Click += new System.EventHandler(this.sell_bu_cli);
            this.Controls.Add(sell_bu);
            hyper_bu.Location = new Point(110,50);
            hyper_bu.Size = new Size(50,30);
            hyper_bu.Text = "SQL";
            hyper_bu.Click += new System.EventHandler(this.hyper_bu_cli);
            this.Controls.Add(hyper_bu);
            status_bu.Location = new Point(170,50);
            status_bu.Size = new Size(50,30);
            status_bu.Text = "user status";
            status_bu.Click += new System.EventHandler(this.status_bu_cli);
            this.Controls.Add(status_bu);
            return_bu.Location = new Point(290,50);
            return_bu.Size = new Size(50,30);
            return_bu.Text = "return";
            return_bu.Click += new System.EventHandler(this.return_bu_cli);
            this.Controls.Add(return_bu);
            search_type.Location = new Point(100,110);
            search_type.Size = new Size(40,30);
            search_type.DataSource = new string[] { "and", "nand", "or", "nor" };
            this.Controls.Add(search_type);
            type_select1.Location = new Point(150,110);
            type_select1.Size = new Size(40,30);
            this.Controls.Add(type_select1);
            type_select2.Location = new Point(200,110);
            type_select2.Size = new Size(40,30);
            this.Controls.Add(type_select2);
            select_exe_bu.Location = new Point(250,110);
            select_exe_bu.Size = new Size(50,30);
            select_exe_bu.Text = "search";
            select_exe_bu.Click += new System.EventHandler(this.select_exe_cli);
            this.Controls.Add(select_exe_bu);
            //hyper
            in_te.Location = new Point(100,100);
            in_te.Size=new Size(300,140);
            in_te.Multiline = true;
            this.Controls.Add(in_te);
            out_te.Location = new Point(100, 300);
            out_te.Size = new Size(300, 150);
            out_te.Multiline = true;
            this.Controls.Add(out_te);
            hyper_send.Location = new Point(100,260);
            hyper_send.Size = new Size(50,20);
            hyper_send.Text = "send";
            hyper_send.Click += new System.EventHandler(this.hyper_send_cli);
            this.Controls.Add(hyper_send);
            //user status
            status_la.Location = new Point(100, 150);
            status_la.Size = new Size(300, 20);
            status_la.BackColor = Color.White;
            this.Controls.Add(status_la);
            select_search_type.Location = new Point(100,190);
            select_search_type.Size = new Size(150,30);
            select_search_type.DataSource = new string[] { "count", "min", "max", "average", "sum" , "item type count" };
            this.Controls.Add(select_search_type);
            status_exe_bu.Location = new Point(300,190);
            status_exe_bu.Size = new Size(50,30);
            status_exe_bu.Text = "search";
            status_exe_bu.Click += new System.EventHandler(this.status_exe_cli);
            this.Controls.Add(status_exe_bu);
            delete_bu.Location = new Point(300,350);
            delete_bu.Size = new Size(50,50);
            delete_bu.Text = "delete\naccount";
            delete_bu.Click += new System.EventHandler(this.delete_cli);
            this.Controls.Add(delete_bu);
            //
            change_status(0);
        }
        private int change_status(int status)
        {
            foreach (item tmp in all)
            {
                this.Controls.Remove(tmp.buy);
                this.Controls.Remove(tmp.price);
                this.Controls.Remove(tmp.word);
                this.Controls.Remove(tmp.name);
            }
            usr.Visible = false;
            pwd.Visible = false;
            usr_te1.Visible = false;
            pwd_te1.Visible = false;
            login_bu.Visible = false;
            create_bu.Visible = false;
            sell_bu.Visible = false;
            hyper_bu.Visible = false;
            in_te.Visible = false;
            out_te.Visible = false;
            hyper_send.Visible = false;
            status_bu.Visible = false;
            status_la.Visible = false;
            select_search_type.Visible = false;
            status_exe_bu.Visible = false;
            return_bu.Visible = false;
            delete_bu.Visible = false;
            type_select1.Visible = false;
            type_select2.Visible = false;
            search_type.Visible = false;
            select_exe_bu.Visible = false;
            switch (status) {
                case 0:
                    usr.Visible = true;
                    pwd.Visible = true;
                    usr_te1.Visible = true;
                    pwd_te1.Visible = true;
                    login_bu.Visible = true;
                    create_bu.Visible = true;
                    break;
                case 1:
                    sell_bu.Visible = true;
                    hyper_bu.Visible = true;
                    status_bu.Visible = true;
                    type_select1.Visible = true;
                    type_select2.Visible = true;
                    search_type.Visible = true;
                    select_exe_bu.Visible = true;
                    show_item();
                    break;
                case 2:
                    in_te.Visible = true;
                    out_te.Visible = true;
                    hyper_send.Visible = true;
                    return_bu.Visible = true;
                    break;
                case 3:
                    status_la.Visible = true;
                    select_search_type.Visible = true;
                    status_exe_bu.Visible = true;
                    return_bu.Visible = true;
                    delete_bu.Visible = true;
                    break;
            }
            return 0;
        }
        private void show_item()
        {
            foreach (item tmp in all)
            {
                this.Controls.Remove(tmp.buy);
                this.Controls.Remove(tmp.price);
                this.Controls.Remove(tmp.word);
                this.Controls.Remove(tmp.name);
            }
            //
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "127.0.0.1";
            conn_string.UserID = "root";
            conn_string.Password = "shadow232";
            conn_string.Database = "world";
            conn_string.Port = 3306;
            conn_string.SslMode = MySqlSslMode.None;
            MySqlConnection conn = new MySqlConnection(conn_string.ToString());
            MySqlCommand command = conn.CreateCommand();
            conn.Open();

            MySqlCommand cmd = new MySqlCommand("select * from item;",conn);
            MySqlDataReader reader = cmd.ExecuteReader(); //execure the reader
            int start_x = 100;
            int start_y = 200;
            item title = new item(this,new Point(start_x,start_y-40));
            title.price.Text = "price";
            title.word.Text = "description";
            title.name.Text = "item";
            title.buy.Visible = false;
            all.Add(title);
            while (reader.Read())
            {
                if (!reader.GetString(5).Equals("0")) {
                    item tmp = new item(this, new Point(start_x, start_y));
                    all.Add(tmp);
                    tmp.item_id = int.Parse(reader.GetString(0));
                    tmp.item_num = int.Parse(reader.GetString(5));
                    tmp.buyer = user_id;
                    tmp.seller = reader.GetString(1);
                    tmp.price.Text = reader.GetString(2);
                    tmp.name.Text = reader.GetString(3);
                    tmp.word.Text = reader.GetString(4);
                    start_y += 30;
                }
            }
            reader.Close();
            //
            cmd = new MySqlCommand("select * from type;", conn);
            reader = cmd.ExecuteReader(); //execure the reader
            List<string> tmps1 = new List<string>();
            List<string> tmps2 = new List<string>();
            while (reader.Read())
            {
                tmps1.Add(reader.GetString(1));
                tmps2.Add(string.Copy(reader.GetString(1)));
            }
            type_select1.DataSource = tmps1;
            type_select2.DataSource = tmps2;
            //
            conn.Close();
        }
        private void login_bu_cli(object sender, EventArgs e) {
            //
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "127.0.0.1";
            conn_string.UserID = "root";
            conn_string.Password = "shadow232";
            conn_string.Database = "world";
            conn_string.Port = 3306;
            conn_string.SslMode = MySqlSslMode.None;
            MySqlConnection conn = new MySqlConnection(conn_string.ToString());
            MySqlCommand command = conn.CreateCommand();
            conn.Open();

            String account=usr_te1.Text;
            String password=pwd_te1.Text;
            MySqlCommand cmd = new MySqlCommand("select PWD from user where UID=\""+account+"\";", conn);
            MySqlDataReader reader = cmd.ExecuteReader(); //execure the reader
            while (reader.Read()) {
                if (reader.GetString(0).Equals(password))
                {
                    user_id = account;
                    change_status(1);
                }
                else {
                    login_bu.Text = "登入\n\nwrong password";
                }
            }
            conn.Close();
        }
        private void create_cli(object sender, EventArgs e)
        {
            //
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "127.0.0.1";
            conn_string.UserID = "root";
            conn_string.Password = "shadow232";
            conn_string.Database = "world";
            conn_string.Port = 3306;
            conn_string.SslMode = MySqlSslMode.None;
            MySqlConnection conn = new MySqlConnection(conn_string.ToString());
            MySqlCommand command = conn.CreateCommand();
            conn.Open();
            //
            String account = usr_te1.Text;
            String password = pwd_te1.Text;
            int flag = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into user values(\"" + account + "\",\"" + password + "\",1);", conn);
                MySqlDataReader reader = cmd.ExecuteReader(); //execure the reader
            }
            catch (Exception ex) {
                create_bu.Text = "ID has\nbeen used";
                flag = 1;
            }
            if (flag==0) {
                create_bu.Text = "sucess";
            }
        }
        private void return_bu_cli(object sender, EventArgs e) {
            //
            change_status(1);
        }
        private void select_exe_cli(object sender, EventArgs e)
        {
            foreach (item tmp in all)
            {
                this.Controls.Remove(tmp.buy);
                this.Controls.Remove(tmp.price);
                this.Controls.Remove(tmp.word);
                this.Controls.Remove(tmp.name);
            }
            //
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "127.0.0.1";
            conn_string.UserID = "root";
            conn_string.Password = "shadow232";
            conn_string.Database = "world";
            conn_string.Port = 3306;
            conn_string.SslMode = MySqlSslMode.None;
            MySqlConnection conn = new MySqlConnection(conn_string.ToString());
            MySqlCommand command = conn.CreateCommand();
            conn.Open();
            //
            string input="";
            string type1 = type_select1.SelectedItem.ToString();
            string type2 = type_select2.SelectedItem.ToString();
            switch (search_type.SelectedItem.ToString())
            {
                case "and":
                    input = "select * from item where  exists (select * from item_type, type where item.ID = item_type.item_id and item_type.type_id = type.ID and type.name = \"" + type1 + "\")"
                                                + "and exists (select * from item_type, type where item.ID = item_type.item_id and item_type.type_id = type.ID and type.name = \"" + type2 + "\")";
                    break;
                case "nand":
                    input = "select * from item where  not exists (select * from item_type, type where item.ID = item_type.item_id and item_type.type_id = type.ID and type.name = \"" + type1 + "\")"
                                                + "and not exists (select * from item_type, type where item.ID = item_type.item_id and item_type.type_id = type.ID and type.name = \"" + type2 + "\")";
                    break;
                case "or":
                    input = "select * from item,item_type,type where item.ID = item_type.item_id and item_type.type_id = type.ID and type.name in (\"" + type1 + "\",\"" + type2 + "\")";
                    break;
                case "nor":
                    input = "select * from item,item_type,type where item.ID = item_type.item_id and item_type.type_id = type.ID and type.name not in (\"" + type1 + "\",\"" + type2 + "\")";
                    break;
            }
            MySqlCommand cmd = new MySqlCommand(input, conn);
            MySqlDataReader reader = cmd.ExecuteReader(); //execure the reader
            int start_x = 100;
            int start_y = 200;
            item title = new item(this, new Point(start_x, start_y - 40));
            title.price.Text = "price";
            title.word.Text = "description";
            title.name.Text = "item";
            title.buy.Visible = false;
            all.Add(title);
            while (reader.Read())
            {
                if (!reader.GetString(5).Equals("0"))
                {
                    item tmp = new item(this, new Point(start_x, start_y));
                    all.Add(tmp);
                    tmp.item_id = int.Parse(reader.GetString(0));
                    tmp.item_num = int.Parse(reader.GetString(5));
                    tmp.buyer = user_id;
                    tmp.seller = reader.GetString(1);
                    tmp.price.Text = reader.GetString(2);
                    tmp.name.Text = reader.GetString(3);
                    tmp.word.Text = reader.GetString(4);
                    start_y += 30;
                }
            }
            reader.Close();
            //
            cmd = new MySqlCommand("select * from type;", conn);
            reader = cmd.ExecuteReader(); //execure the reader
            List<string> tmps1 = new List<string>();
            List<string> tmps2 = new List<string>();
            while (reader.Read())
            {
                tmps1.Add(reader.GetString(1));
                tmps2.Add(string.Copy(reader.GetString(1)));
            }
            type_select1.DataSource = tmps1;
            type_select2.DataSource = tmps2;
            //
            conn.Close();
        }
        private void sell_bu_cli(object sender, EventArgs e)
        {
            //
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "127.0.0.1";
            conn_string.UserID = "root";
            conn_string.Password = "shadow232";
            conn_string.Database = "world";
            conn_string.Port = 3306;
            conn_string.SslMode = MySqlSslMode.None;
            MySqlConnection conn = new MySqlConnection(conn_string.ToString());
            MySqlCommand command = conn.CreateCommand();
            conn.Open();

            Random r = new Random();
            int price = r.Next(100,200);
            int amount = r.Next(1,5);
            string name = r.Next(1,999).ToString();
            string word = r.Next(1, 9999999).ToString();
            MySqlCommand cmd = new MySqlCommand("insert into item(seller,price,name,word,isselled) values(\""+user_id+"\","+price+",\""+name+"\",\""+word+"\","+amount+");", conn);
            MySqlDataReader reader = cmd.ExecuteReader(); //execure the reader

            //
            show_item();
        }
        private void hyper_bu_cli(object sender, EventArgs e) {
            change_status(2);
        }
        private void hyper_send_cli(object sender, EventArgs e)
        {
            //
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "127.0.0.1";
            conn_string.UserID = "root";
            conn_string.Password = "shadow232";
            conn_string.Database = "world";
            conn_string.Port = 3306;
            conn_string.SslMode = MySqlSslMode.None;
            MySqlConnection conn = new MySqlConnection(conn_string.ToString());
            MySqlCommand command = conn.CreateCommand();
            conn.Open();

            string input = in_te.Text;
            MySqlCommand cmd = new MySqlCommand(input, conn);
            MySqlDataReader reader = cmd.ExecuteReader(); //execure the reader

            out_te.Text = "";
            while (reader.Read()) {
                for (int i=0;i<reader.FieldCount;++i) {
                    out_te.Text += (reader.GetString(i)+"\t");
                }
                out_te.Text += Environment.NewLine;
            }
        }
        private void status_bu_cli(object sender, EventArgs e) {
            //
            change_status(3);
        }
        private void status_exe_cli(object sender, EventArgs e)
        {
            //
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "127.0.0.1";
            conn_string.UserID = "root";
            conn_string.Password = "shadow232";
            conn_string.Database = "world";
            conn_string.Port = 3306;
            conn_string.SslMode = MySqlSslMode.None;
            MySqlConnection conn = new MySqlConnection(conn_string.ToString());
            MySqlCommand command = conn.CreateCommand();
            conn.Open();
            //
            string input = "";
            switch (select_search_type.SelectedItem.ToString())
            {
                case "count":
                    input= "select count(ID) from trade_record where buyer_id=\"" + user_id + "\";";
                    break;
                case "min":
                    input = "select min(price) from trade_record,item where buyer_id=\"" + user_id + "\" and trade_record.item_id=item.ID;";
                    break;
                case "max":
                    input = "select max(price) from trade_record,item where buyer_id=\"" + user_id + "\" and trade_record.item_id=item.ID;";
                    break;
                case "average":
                    input = "select avg(price) from trade_record,item where buyer_id=\"" + user_id + "\" and trade_record.item_id=item.ID;";
                    break;
                case "sum":
                    input = "select sum(price) from trade_record,item where buyer_id=\"" + user_id + "\" and trade_record.item_id=item.ID;";
                    break;
                case "item type count":
                    input = "select count(distinct item_type.item_id) from trade_record,item,item_type where buyer_id=\"" + user_id + "\" and trade_record.item_id=item.ID and item.ID=item_type.item_id group by item_type.item_id having count(item_type.type_id);";
                    break;
            }
            //
            MySqlCommand cmd = new MySqlCommand(input, conn);
            MySqlDataReader reader = cmd.ExecuteReader(); //execure the reader
            reader.Read();
            status_la.Text = select_search_type.SelectedItem.ToString() + " : " + reader.GetString(0);
            reader.Close();
        }
        private void delete_cli(object sender, EventArgs e)
        {
            //
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "127.0.0.1";
            conn_string.UserID = "root";
            conn_string.Password = "shadow232";
            conn_string.Database = "world";
            conn_string.Port = 3306;
            conn_string.SslMode = MySqlSslMode.None;
            MySqlConnection conn = new MySqlConnection(conn_string.ToString());
            MySqlCommand command = conn.CreateCommand();
            conn.Open();
            //
            string input = "delete from user where UID=\""+user_id+"\"";
            MySqlCommand cmd = new MySqlCommand(input, conn);
            MySqlDataReader reader = cmd.ExecuteReader(); //execure the reader
            change_status(0);
        }
        class item {
            public int item_id;
            public int item_num;
            public string seller;
            public string buyer;
            public Label name;
            public Label word;
            public Label price;
            public Button buy;
            public Form1 parents;
            //
            public item(Form1 parent,Point ini) {
                name = new Label();
                name.Location = ini;
                name.Size = new Size(50,30);
                parent.Controls.Add(name);
                parents = parent;
                //
                word = new Label();
                word.Location = new Point(ini.X+60,ini.Y);
                word.Size = new Size(150, 30);
                parent.Controls.Add(word);
                //
                price = new Label();
                price.Location = new Point(ini.X+220,ini.Y);
                price.Size = new Size(50, 30);
                parent.Controls.Add(price);
                //
                buy = new Button();
                buy.Location = new Point(ini.X+280,ini.Y-10);
                buy.Size = new Size(50, 30);
                buy.Text = "buy";
                buy.Click += new System.EventHandler(buy_cli);
                parent.Controls.Add(buy);
            }
            private void buy_cli(object sender, EventArgs e) {
                //
                MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
                conn_string.Server = "127.0.0.1";
                conn_string.UserID = "root";
                conn_string.Password = "shadow232";
                conn_string.Database = "world";
                conn_string.Port = 3306;
                conn_string.SslMode = MySqlSslMode.None;
                MySqlConnection conn = new MySqlConnection(conn_string.ToString());
                MySqlCommand command = conn.CreateCommand();
                conn.Open();
                //
                command.CommandText = "insert into trade_record(item_id, seller_id, buyer_id, time) values("+item_id+", \""+seller+"\", \""+buyer+"\",now());";
                command.ExecuteNonQuery();
                command.CommandText = "update item set isselled="+(item_num-1)+" where ID="+item_id+";";
                command.ExecuteNonQuery();

                //
                parents.show_item();
            }
        }
    }
}
