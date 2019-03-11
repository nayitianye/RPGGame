using System;
using System.Windows.Forms;
using NpcCharacter;
namespace NpcCharacter
{
    public class Task
    {
        public static void story(int i)
        {
            DialogResult r1;
            if (i == 0)
            {
                r1 = MessageBox.Show("我是女孩");
            }
            if (i == 1)
            {
                r1 = MessageBox.Show("我是男孩");
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
        }
    }
}
