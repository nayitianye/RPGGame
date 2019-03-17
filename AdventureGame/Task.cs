using System.Windows.Forms;
namespace AdventureGame
{
    public class Task
    {
        public static int p = 0;
        public static Player.Status player_last_status = Player.Status.WALK;
        public static void Story(int i)
        {
            if(Player.status!=Player.Status.TASK)
            {
                player_last_status = Player.status;
            }
            Player.status = Player.Status.TASK;
            DialogResult r1;
            if (i == 0)
            {
                if (p == 0)
                {
                    Message.Showtip("一只破鞋");
                    Block();
                }
                else if (p == 1)
                {
                    Message.Showtip("捡起破鞋");
                    Block();
                    Form1.npcs[0].x = -100;
                    p = 2;
                }
                else if (p == 2)
                {
                   
                }
            }
            if (i == 1)
            {
                if (p == 0)
                {
                    Message.Show("陌生人", "年轻人，我看你智慧超群，天资聪慧，是百年难得一见的游戏奇才，去，把下面那只鞋给我捡回来。", "face4_2.png", Message.Face.RIGHT);
                    Block();
                    Message.Show("主角", "真是个没礼貌的年轻人，不理你了。", "face2_1.png", Message.Face.LEFT);
                    Block();
                    Message.Show("陌生人", "拜托，年轻人，好好配合一下，不然剧情怎么发展？", "face4_2.png", Message.Face.RIGHT);
                    Block();
                    Message.Show("主角", "好吧，算我倒霉，遇到怪人了。", "face2_1.png", Message.Face.LEFT);
                    Block();
                    p = 1;

                }
                else if (p == 1)
                {
                    Message.Show("陌生人", "还不快去捡鞋。", "face4_2.png", Message.Face.RIGHT);
                    Block();
                }
                else if (p == 2)
                {
                    Message.Show("陌生人", "孺子可教也。我这里有一本奇书，就此传授于你。你要下苦功钻研这部书。钻研透了，以后可以做帝王的老师。十年后必定有大成就。", "face4_2.png", Message.Face.RIGHT);
                    Block();
                    Message.Showtip("获得《罗培羽书》");
                    Block();
                    Item.Add_item(5, 1);
                    p = 3;
                }
                else if (p == 3)
                {
                    Message.Show("陌生人", "孺子可教也。", "face4_2.png", Message.Face.RIGHT);
                    Block();
                }
            }
            if (i == 2)
            {
                Map.Change_map(Form1.maps, Form1.players, Form1.npcs, 1, 955, 550, 2, Form1.music_player);
            }
            if (i == 3)
            {
                Map.Change_map(Form1.maps, Form1.players, Form1.npcs, 0, 45, 500, 3, Form1.music_player);
            }
            if (i == 4)
            {
                Form1.npcs[4].Play_aniation(0);
            }
            if (i == 6)
            {
                Shop.Show(new int[] { 0, 1, 2, 3, -1, -1, -1 });
                Block();
            }
            Player.status = player_last_status;
        }
        //
        public static void Block()
        {
            while (Player.status == Player.Status.PANEL)
            {
                Application.DoEvents();
            }
        }
    }
}
