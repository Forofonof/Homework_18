using System;

internal class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();

        int playerHealth = random.Next(225, 305);
        int playerManaPool = random.Next(135, 165);
        int bossHealth = random.Next(295, 400);
        int bossDamage;
        int spellGhostArrow;
        int spellGhostArrowMana = 10;
        int spellBallLightning;
        int spellBallLightningMana = 15;
        int spellSacrificeToGodsHealth = 50;
        int spellTemporaryBreak;
        int spellTemporaryBreakMana = 50;
        int spellDivineShield;
        int spellDivineShieldMana = 25;
        int spellUnknown;
        int spellUnknownMana = 50;
        int spellUsedCount = 0;
        string spellSelection;
        bool isSacrificeWasMade = false;
        bool IsActiveGame = true;

        Console.WriteLine("Вас атакует босс! Какое заклинание будете использовать?");
        Console.WriteLine($"Маг: {playerHealth} Здоровья. {playerManaPool} Маны. Босс: {bossHealth} Здоровья.");

        while (IsActiveGame == true)
        {
            Console.WriteLine($"1 - Призрачная стрела. Обычное заклинание.\nНужно: {spellGhostArrowMana} Маны.\n2 - Шаровая молния. Редкое заклинание.\nНужно: Призрачная стрела и {spellBallLightningMana} Маны.");
            Console.WriteLine($"3 - Временной разлом. Эпическое заклинание.\nНужно: Жертва богам и {spellTemporaryBreakMana} Маны.");
            Console.WriteLine($"4 - Божественный щит. Дает возможность исцелить себя во время боя.\nНужно: {spellDivineShieldMana} Маны.");
            Console.WriteLine($"5 - Жертва богам. Дает благословение всего на одно заклинание.\nНужно: {spellSacrificeToGodsHealth} Здоровья.");
            spellSelection = Console.ReadLine();

            switch (spellSelection)
            {
                case "1":
                    if (playerManaPool >= spellGhostArrowMana)
                    {
                        playerManaPool -= spellGhostArrowMana;
                        playerHealth -= bossDamage = random.Next(50, 125);
                        bossHealth -= spellGhostArrow = random.Next(35, 80);
                        spellUsedCount++;

                        Console.WriteLine($"Маг: {playerHealth} Здоровья. {playerManaPool} Маны.\nБосс: {bossHealth} Здоровья.");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Вы нанесли урона: {spellGhostArrow}.");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Вам нанесли урона: {bossDamage}.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        playerHealth -= bossDamage = random.Next(50,85);

                        Console.WriteLine("Вы не заметили, что у вас недостаточно маны, для использования заклинания.\nТолько не думайте, что противник этим не воспользуется.");
                        Console.WriteLine($"Вам нанесли {bossDamage} урона.");
                        Console.ResetColor();
                    }
                    break;
                case "2":
                    if (playerManaPool >= spellBallLightningMana && spellUsedCount >= 1)
                    {
                        playerManaPool -= spellBallLightningMana;
                        playerHealth -= bossDamage = random.Next(50, 125);
                        bossHealth -= spellBallLightning = random.Next(90, 150);

                        Console.WriteLine($"Маг: {playerHealth} Здоровья. {playerManaPool} Маны.\nБосс: {bossHealth} Здоровья.");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Вы нанесли урона: {spellBallLightning}.");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Вам нанесли урона: {bossDamage}.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        playerHealth -= bossDamage = random.Next(50, 85);

                        Console.WriteLine("Вы не заметили, что у вас недостаточно ауры, для использования заклинания.\nТолько не думайте, что противник этим не воспользуется.");
                        Console.WriteLine($"Вам нанесли {bossDamage} урона.");
                        Console.ResetColor();
                    }
                    break;
                case "3":
                    if (isSacrificeWasMade == true)
                    {
                        playerManaPool -= spellTemporaryBreakMana;
                        playerHealth -= bossDamage = random.Next(75, 125);
                        bossHealth -= spellTemporaryBreak = random.Next(195, 225);
                        isSacrificeWasMade = false;

                        Console.WriteLine($"Маг: {playerHealth} Здоровья. {playerManaPool} Маны.\nБосс: {bossHealth} Здоровья.");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Вы нанесли урона: {spellTemporaryBreak}.");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Вам нанесли урона: {bossDamage}.");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Вы использовали закливнание 'Временной разлом', боги гордятся вами.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        playerHealth -= bossDamage = random.Next(50, 125);

                        Console.WriteLine("Боги не готовы даровать вам это заклинание, без жертвоприношения.\nБосс учуял вашу невнимательность и нанес урон.");
                        Console.WriteLine($"Вам нанесли {bossDamage} урона.");
                        Console.ResetColor();
                    }
                    break;
                case "4":
                    if (playerManaPool >= spellDivineShieldMana)
                    {
                        playerManaPool -= spellDivineShieldMana;
                        playerHealth += spellDivineShield = random.Next(85, 155);
                        playerHealth -= bossDamage = random.Next(30, 70);

                        Console.WriteLine($"Маг: {playerHealth} Здоровья. {playerManaPool} Маны.\nБосс: {bossHealth} Здоровья.");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Вы исцелили себе: {spellDivineShield} Здоровья.");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Вам нанесли урона: {bossDamage}.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        playerHealth -= bossDamage = random.Next(50, 85);

                        Console.WriteLine("Вы не заметили, что у вас недостаточно маны, для использования заклинания.\nТолько не думайте, что противник этим не воспользуется.");
                        Console.WriteLine($"Вам нанесли {bossDamage} урона.");
                        Console.ResetColor();
                    }
                    break;
                case "5":
                    if (playerHealth >= spellSacrificeToGodsHealth)
                    {
                        playerHealth -= spellSacrificeToGodsHealth;
                        playerHealth -= bossDamage = random.Next(25, 75);
                        isSacrificeWasMade = true;

                        Console.WriteLine($"Маг-адепт: {playerHealth} Здоровья. {playerManaPool} Маны. Босс: {bossHealth} Здоровья.");
                        Console.WriteLine($"Вам нанесли урона: {bossDamage}.");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Вы сделали жертву богам.\nНе переживайте, это больше ментальная жертва, во благо всего мира.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        playerHealth -= bossDamage = random.Next(195, 275);

                        Console.WriteLine("Вы не заметили, что у вас недостаточно здоровья, для жертвоприношения богам.\nБосс почуял вашу слабость и нанёс по вам критический урон.");
                        Console.WriteLine($"Вам нанесли {bossDamage} урона.");
                        Console.ResetColor();
                    }
                    break;
                default:
                    playerHealth -= bossDamage = random.Next(100, 200);
                    playerManaPool -= spellUnknownMana;
                    bossHealth -= spellUnknown = random.Next(10, 275);

                    Console.WriteLine($"Маг-адепт: {playerHealth} Здоровья. {playerManaPool} Маны. Босс: {bossHealth} Здоровья.");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Вы попытались сотворить заклинание, которого не знаете. Что ж, надеюсь, это была не коровая ошибка.\nБосс почуял вашу неуверенность.");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Вам нанесли урона: {bossDamage}.");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Вы нанесли урона: {spellUnknown}");
                    Console.ResetColor();
                    break;
            }
            if (playerHealth <= 0 && bossHealth > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Вы мертвы!\nБосс ликует над вашим поражением и становиться сильнее. Кто же теперь спасет королевство?");
                IsActiveGame = false;
                Console.ResetColor();
            }
            else if (playerManaPool <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("У вас недостаточно маны, что продолжать бой.\nЭто действительно глупое поражение!");
                IsActiveGame = false;
                Console.ResetColor();
            }
            if (bossHealth <= 0 && playerHealth > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Победа! Вы одолели босса.\nКакая же теперь у вас цель?");
                IsActiveGame = false;
                Console.ResetColor();
            }
            else if (bossHealth <= 0 && playerHealth <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Ничья!\nТолько не стоит думать, что это единственная угроза королевства, остается лишь надеяться, что объявится новый герой...");
                IsActiveGame = false;
                Console.ResetColor();
            }
        }
    }
}