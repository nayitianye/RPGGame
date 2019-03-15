using System.Windows.Forms;
namespace MouseController
{
    public class Task
    {
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
                Message.Show("主角","夏山如碧，绿树成荫，总会令人依然自乐。此地山清水秀，我十分喜爱。我们便约好了，闲暇时，便来此地，沏茶共饮。", "face1_1.png",Message.Face.LEFT);
                Block();
                Message.Show("女孩", "嗯，说好了，一言为定。可是怎么感觉你这句话是山寨自哪里的。", "face3_2.png", Message.Face.RIGHT);
                Block();
                Message.Show("主角", "(被发现了TAT)", "face2_1.png", Message.Face.LEFT);
                Block();
            }
            if (i == 1)
            {
                Message.Showtip("遇到一个人");
                Block();
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
