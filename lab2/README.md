# Варіант 12
Багато хто, ймовірно, чув пісні про пригоди жабка Crazy Frog. Цього разу невгамовне миле створення вирішило підкріпитися, 
але навіть таку просту дію вирішило виконати у вигляді гри. Отже, у кожній клітині квадратного ігрового поля, розбитого на N×N (N ≤ 50) клітин, 
знаходиться один комар вагою aij (вага комара – натуральне число ≤ 50), i – номер рядка, j – номер стовпця. 
Жабеня, стрибаючи з клітини на клітину, їсть комарів. Правила гри такі - у кожному стовпці можна з'їсти трохи більше одного комара. 
Щоразу при з'їданні комара запам'ятовуємо номер рядка, звідки з'їдено комар, і сума номерів рядків, у яких з'їдено комарі, наприкінці гри має бути точно дорівнює N. 
Врахуйте, якщо з якогось рядка з'їдено кілька комарів, то номер даного рядка бере участь у підсумовуванні більше одного разу.
Визначте максимальну вагу комарів, яку можна з'їсти при дотриманні наведених правил.
Перший рядок вхідного файлу INPUT.TXT містить число N. Наступні N рядків містять N чисел aij, розділених пробілами.

Файли INPUT.txt та OUTPUT.txt знаходяться за шляхом lab2\bin\Debug\net7.0