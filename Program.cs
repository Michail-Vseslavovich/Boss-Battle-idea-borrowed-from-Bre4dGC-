var hero = new Hero(100, 2, 10);
var boss = new Boss(150, 2, 12);




while (true)
{
    hero.Attack(boss);
    boss.Attack(hero);
    Console.WriteLine("хп игрока = {0} \n хп босса = {1}", hero.GetHealth(), boss.GetBossHp());
    if (hero.GetHealth() <= 0) 
    {
        Console.WriteLine("БОСС ВЫИГРАЛ!!!!!!!!!!11111!!!!!");
        break;
    }

    else if (boss.GetBossHp() <= 0) 
    {
        Console.WriteLine("ТЫ ВЫИГРАЛ!!111!!!! ДЕРЖИ ВОЗДУХ!!!");
        break ;
    }
}





class Hero
{
    Random heal = new Random();
    private int health;
    private int armor;
    private int attack;


    public void SetHealth(int damage)
    { this.health -= damage/armor; }

    public int GetHealth() 
    { return this.health; }


    public Hero(int health, int armor,int attack)
    {
        this.health = health;
        this.armor = armor;
        this.attack = attack;
    }
    public void Attack(Boss boss)
    {
        Console.WriteLine("Введите номер атаки");
        string user_input = Console.ReadLine();
        switch (user_input)
        {
            case ("1"):
                Console.WriteLine("Игрок атакует слабой атакой");
                boss.SetBossHealth(attack);
                break;
            case ("2"):
                Console.WriteLine("Игрок атакует обоюродоострым мечём");
                boss.SetBossHealth(attack*2);
                health -= 10; break;
            case ("3"):
                Console.WriteLine("Игрок хилит себя");
                health += heal.Next(10, 25);
                break;

        }
    }
}


class Boss
{
    Random heal = new Random();
    Random attack = new Random();

    private int BossHealth;
    private int BossArmor;
    private int BossAttack;
    

    public Boss(int bossHealth, int bossArmor, int bossAttack)
    {
        
        BossHealth = bossHealth;
        BossArmor = bossArmor;
        BossAttack = bossAttack;
    }

    public void SetBossHealth(int damage)
    {
        this.BossHealth -= damage / this.BossArmor;
    }
    public int GetBossHp()
    { return this.BossHealth; }

    public void Attack(Hero hero)
    {
        int attemp = attack.Next(1,3);
        switch (attemp)
        {
            case 1:
                Console.WriteLine("Босс атакует слабой атакой");
                hero.SetHealth(BossAttack);
                break;

            case 2:
                Console.WriteLine("Босс атакует обоюродоострым мечём");
                hero.SetHealth(BossAttack *2);
                this.BossHealth -= 10; break;
            case 3:
                Console.WriteLine("Босс хилит себя");
                this.BossHealth += heal.Next(10, 30);
                break;
        }
    }

}
