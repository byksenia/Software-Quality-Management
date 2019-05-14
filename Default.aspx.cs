using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class _Default : System.Web.UI.Page
{
    const int n = 11;
    const int k = 10;
    public class item
    {
        public int s, c, v;
        public item(int s, int c, int v)
        {
            this.s = s;
            this.c = c;
            this.v = v;
        }
    };


    item[] graph = new item[] { new item(1,2,3), new item(1,3,2), new item (2,4,5), new item(2,5,2), new item(3,6,1), new item(5,7,3)
    ,new item (5,6,6), new item (7,10,8), new item (6,8,3), new item (8,9,4)};
    int[] road = new int[n];
    bool[] incl = new bool[n];
    int[] way = new int[n];
    int waylen;
    int start, finish;
    bool found;
    int len;
    int c_len;
    bool fr = false;


    int find(int s, int c)
    {
        for (int i = 0; i < k; i++)
            if (graph[i].s == s && graph[i].c == c ||
               graph[i].s == c && graph[i].c == s) return graph[i].v;
        return 0;
    }
    void step(int s, int f, int p)
    {
        int c;
        if (s == f)
        {
            found = true;
            len = c_len;
            waylen = p;
            for (int i = 0; i < waylen; i++) way[i] = road[i];
        }
        else
        {
            for (c = 0; c < n; c++)
            {
                int w = find(s, c);
                if ((w != 0) && !incl[c] && (len == 0 || c_len + w < len))
                {
                    road[p] = c;
                    incl[c] = true;
                    c_len += w;
                    step(c, f, p + 1);
                    road[p] = 0;
                    incl[c] = false;
                    c_len -= w;
                }
            }
        }
    }
    void ways(int st, int fin)
    {
        //Инициализация данных:
        for (int i = 0; i < n; i++)
        {
            road[i] = way[i] = 0; incl[i] = false;
        }
        len = c_len = waylen = 0;
        start = st;
        finish = fin;
        road[0] = start;
        incl[start] = true;
        found = false;
        step(start, finish, 1);
    }

  

    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        TextBox3.Text = "";
        if ((TextBox1.Text.Equals("")) || (TextBox2.Text.Equals("")))
        {
            //MessageBox:Show("Ошибка ввода! \nДанные не введены!", "ERROR", MessageBoxButtons.OK);
            TextBox3.Text = "Вы не ввели все необходимые данные!";
        }
        else
        {
            string Str1 = TextBox1.Text.Trim();
            string Str2 = TextBox2.Text.Trim();
            int Num;
            bool isNum = int.TryParse(Str1, out Num);
            bool isNum2 = int.TryParse(Str2, out Num);
            if (isNum && isNum2)
            {
                int a = Convert.ToInt32(Str1);
                int b = Convert.ToInt32(Str2);
                if ((a >= 1) || (a <= 10) && (b >= 1) || (b <= 10))
                {
                    ways(a, b);
                    if (found)
                    {
                        for (int i = 0; i < waylen; i++)
                        {
                            
                                TextBox3.Text = TextBox3.Text + " -> " + way[i];
                            
                           
                        }
                        
                        
                            
                        
                    }
                    else { TextBox3.Text = "Путь не найден!"; }
                    // действие если строка - число
                }
                else { TextBox3.Text = "Путь не найден! "; }
            }
            else
            {
                TextBox3.Text = "Вы ввели некорректные данные!";
                // действие если строка - не число

            }
        }


    }
   
}



    
        
