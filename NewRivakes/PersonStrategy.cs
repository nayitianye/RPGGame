namespace NewRivakes
{
    public abstract class PersonStrategy
    {
        public abstract  Protagonist SetAttribute(Protagonist protagonist);

    }
    public class DecentStrategy : PersonStrategy
    {
        public override Protagonist SetAttribute(Protagonist protagonist)
        {
            protagonist.Attack = 10;
            protagonist.Defense = 10;
            protagonist.Furtune = 5;
            protagonist.Speed =5;
            protagonist.Power =5;
            protagonist.Yan_attack = 2;
            protagonist.Yin_attack = 0;
            protagonist.Mo_attack = 0;
            protagonist.Yan_defense = 2;
            protagonist.Yin_defense = 0;
            protagonist.Mo_defense = 0;
            protagonist.Image_path = "protagonist/ren1x.jpg";
            protagonist.Role = 1;
            return protagonist;
        }
    }
    public class CultStrategy : PersonStrategy
    {
        public override Protagonist SetAttribute(Protagonist protagonist)
        {
            protagonist.Attack = 12;
            protagonist.Defense = 8;
            protagonist.Furtune = 3;
            protagonist.Speed = 7;
            protagonist.Power = 3;
            protagonist.Yan_attack = 0;
            protagonist.Yin_attack = 2;
            protagonist.Mo_attack = 0;
            protagonist.Yan_defense = 0;
            protagonist.Yin_defense = 2;
            protagonist.Mo_defense = 0;
            protagonist.Image_path = "protagonist/ren3x.jpg";
            protagonist.Role = 2;
            return protagonist;
        }
    }
    public class MagicStrategy : PersonStrategy
    {
        public override Protagonist SetAttribute(Protagonist protagonist)
        {
            protagonist.Attack = 8;
            protagonist.Defense = 12;
            protagonist.Furtune = 4;
            protagonist.Speed = 3;
            protagonist.Power = 7;
            protagonist.Yan_attack = 0;
            protagonist.Yin_attack = 0;
            protagonist.Mo_attack = 2;
            protagonist.Yan_defense = 0;
            protagonist.Yin_defense = 0;
            protagonist.Image_path = "protagonist/ren2x.jpg";
            protagonist.Mo_defense = 3;
            return protagonist;
        }
    }
}
