using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Algor_04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtOpen_Click(object sender, EventArgs e){
            //================================================ 讀檔開始 ====================================================
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";

            if (openFileDialog1.ShowDialog() == DialogResult.OK){

                StreamReader DataIn_culcu_row = new StreamReader(openFileDialog1.FileName);//建構列統計用資料流物件
                StreamReader DataIn_culcu_column = new StreamReader(openFileDialog1.FileName);//建構行統計用資料流物件
                int Rows = 0, Column = 0;//用於統計列與行的數量,以作為洛杉磯地圖二維陣列的索引變數
                string[] buffer = { "" };//暫存字串用
                char[] separatorS = { ' ' };//分割符            
                //================================================ 開始統計 ====================================================
                while (!DataIn_culcu_row.EndOfStream){
                    buffer[0] = DataIn_culcu_row.ReadLine();
                    Rows++;
                }
                L_A.IntegerMap = new int[Rows][];//一維空間的索引上限取得
                L_A.BuildinGMap = new BuildinG[Rows][];
                //================================================ 列統計完畢 ==================================================
                for (int i = 0; i < Rows; i++){
                    buffer = DataIn_culcu_column.ReadLine().Split(separatorS);
                    Column = buffer.GetLength(0);//取得此列的元素個數

                    L_A.IntegerMap[i] = new int[Column];//建構一行空間並放入該列中
                    L_A.BuildinGMap[i] = new BuildinG[Column];

                    for (int j = 0; j < Column; j++){
                        L_A.IntegerMap[i][j] = Int32.Parse(buffer[j]);  //紀錄該座標之建築種類
                        L_A.BuildinGMap[i][j] = new BuildinG(i, j, Int32.Parse(buffer[j])); //建構該座標之建築
                        this.Controls.Add(L_A.BuildinGMap[i][j]);
                        if (L_A.IntegerMap[i][j] == 4) L_A.Plissken = new Snake(i, j); //如果為起點,則設定大蛇站立的位置
                    }
                }
                //============================== 行統計完畢並完成洛杉磯的全圖,讀檔到此結束 =====================================
                L_A.Plissken.Escape();
                //======================================= 已脫逃並取得脫逃的路徑 ===============================================
                //開始比較哪條路徑最短
                int IndexOfMin = 0;
                for (int i = 1; i < L_A.EscapeRouteS_num; i++)
                    if (L_A.EscapeRouteS[i].Count < L_A.EscapeRouteS[IndexOfMin].Count) IndexOfMin = i;
                //=========================================== 已找出最短路徑 ===================================================
                txtOpen.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 119, 44, 174); //辨識用,無意義
                //============================================ 開始輸出路徑 ====================================================                
                
                int Current_I=0,Current_J=0,Last_I=0,Last_J=0; //紀錄現在座標與上次座標
                int Delta_I=0,Delta_J=0; //由位置的變化判斷要使用哪個方向圖片

                while (L_A.EscapeRouteS[IndexOfMin].Count > 0) { 
                    Current_I=L_A.EscapeRouteS[IndexOfMin].Peek().Axis_I;
                    Current_J=L_A.EscapeRouteS[IndexOfMin].Peek().Axis_J;
                    if (L_A.IntegerMap[Current_I][Current_J] == 0) { 
                        //非起點,終點,則可以畫方向圖
                        Delta_I = Current_I - Last_I;
                        Delta_J = Current_J - Last_J;
                        if (Delta_I > 0) L_A.BuildinGMap[Current_I][Current_J].BackgroundImage=Algor_04.Properties.Resources.down;//往下
                        else if (Delta_I < 0) L_A.BuildinGMap[Current_I][Current_J].BackgroundImage = Algor_04.Properties.Resources.up;//往上
                        else if (Delta_J > 0) L_A.BuildinGMap[Current_I][Current_J].BackgroundImage = Algor_04.Properties.Resources.right;//往右
                        else L_A.BuildinGMap[Current_I][Current_J].BackgroundImage = Algor_04.Properties.Resources.left;//往左
                    }
                    Last_I = Current_I;
                    Last_J = Current_J;
                    L_A.EscapeRouteS[IndexOfMin].Pop();
                }
            }
        }
    }
}


class L_A{
    public static int[][] IntegerMap = null;//洛杉磯的地圖of整數型態
    public static BuildinG[][] BuildinGMap = null;//洛杉磯的地圖of建築型態
    public static Stack<Location>[] EscapeRouteS = new Stack<Location>[1000000];//紀錄路徑
    public static int EscapeRouteS_num = 0;//路徑數量
    public static Snake Plissken;
}

class Location{
    //========== Member Variable ===========
    public int Axis_I = 0; //座標的I軸
    public int Axis_J = 0; //座標的J軸
    //============ Constructor =============
    public Location(int _I, int _J){
        Axis_I = _I;
        Axis_J = _J;
    }
    public Location(Location L1){
        Axis_I = L1.Axis_I;
        Axis_J = L1.Axis_J;
    }
}

class Snake{
    //========== Member Variable ===========
    public Location He_Stand_On = null; //站立點座標
    public Stack<Location> He_Walked = new Stack<Location>(); //座標堆疊,紀錄路徑用 
    //============ Constructor =============
    public Snake(int _i, int _j){
        He_Stand_On = new Location(_i, _j);
        He_Walked.Push(new Location(He_Stand_On));
    }
    //========== Member Function ===========
    public void Move(int Dva){
        if (Dva == 0) He_Stand_On.Axis_J++;  //向右走
        else if (Dva == 1) He_Stand_On.Axis_I++;  //向下走
        else if (Dva == 2) He_Stand_On.Axis_J--;  //向左走
        else if (Dva == 3) He_Stand_On.Axis_I--;  //向上走
    }
    public void Back(int Dva){
        if (Dva == 0) He_Stand_On.Axis_J--;  //向左走
        else if (Dva == 1) He_Stand_On.Axis_I--;  //向上走
        else if (Dva == 2) He_Stand_On.Axis_J++;  //向右走
        else if (Dva == 3) He_Stand_On.Axis_I++;  //向下走
    }
    public bool CanMove(int Genji){
        int If_Move_I = He_Stand_On.Axis_I;
        int If_Move_J = He_Stand_On.Axis_J;

        if (Genji == 0) If_Move_J++;  //向右走
        else if (Genji == 1) If_Move_I++;  //向下走
        else if (Genji == 2) If_Move_J--;  //向左走
        else if (Genji == 3) If_Move_I--;  //向上走

        if (L_A.IntegerMap[If_Move_I][If_Move_J] == 0) return true;
        else if (L_A.IntegerMap[If_Move_I][If_Move_J] == 3) return true;
        else return false;
    }
    public int Stand_on_What(){
        return L_A.IntegerMap[He_Stand_On.Axis_I][He_Stand_On.Axis_J];
    }
    public void Escape(){
        if (Stand_on_What() == 3){
            //如果為終點
            L_A.EscapeRouteS[L_A.EscapeRouteS_num] = new Stack<Location>(He_Walked.ToArray());//將完成的路徑紀錄至堆疊陣列中,注意!!此處new的堆疊複製體方向會反轉!!
            L_A.EscapeRouteS_num++; //堆疊陣列的紀錄點往下一個移動
            He_Walked.Pop(); //移除此點
            return;
        }

        if (Stand_on_What() != 4) L_A.IntegerMap[He_Stand_On.Axis_I][He_Stand_On.Axis_J] = 2;//此點檢查中

        //如果不為終點則開始檢查
        for (int i = 0; i < 4; i++){
            if (CanMove(i)){
                //可移動
                Move(i);   //先做移動
                He_Walked.Push(new Location(L_A.Plissken.He_Stand_On)); //紀錄路徑
                Escape(); //檢查此點
                Back(i);   //記錄完後回到原點
            }
        }

        //如果四方位皆走過,則移除此點並返回;
        if (Stand_on_What() != 4){
            L_A.IntegerMap[He_Stand_On.Axis_I][He_Stand_On.Axis_J] = 0;//此點檢查完畢,可恢復通行
            He_Walked.Pop(); //從路徑中移除此點
        }
        return;
    }
}

class BuildinG : PictureBox
{
    // =========== Member Variable =============
    // ============= Constructor ===============
    public BuildinG(int Lox, int Loy, int BuildingType){
        BackColor = Color.Gold;
        Location = new Point(150 + 32 * Loy, 70 + 32 * Lox);
        Height = 32;
        Width = 32;
        //基本設定結束
        if (BuildingType == 0) BackgroundImage = Algor_04.Properties.Resources.road;
        else if (BuildingType == 1) BackgroundImage = Algor_04.Properties.Resources.brick;
        else if (BuildingType == 3) BackgroundImage = Algor_04.Properties.Resources.fire_exit_sign;
        else if (BuildingType == 4) BackgroundImage = Algor_04.Properties.Resources.fugade18;
    }
}