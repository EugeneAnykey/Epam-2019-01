# Занятие 04. Работа со строками, регулярные выражения

## Задания

### Задание 1

Написать программу, которая определяет среднюю длину слова во введенной текстовой строке. Учесть, что символы пунктуации на длину слов влиять не должны. Используйте стандартные методы класса **String**.

### Задание 2

Написать программу, которая удваивает в первой введенной строке все символы, принадлежащие второй введенной строке.

> Пример:

```txt
Введите первую строку: написать программу, которая
Введите вторую строку: описание
Результирующая строка: ннааппииссаать ппроограамму, коотоораая
```

### Задание 3

Разработать консольное приложение, которое выводит на экран (в виде таблицы) отличия в параметрах культур:

* ***ru*** vs ***en***
* ***en*** vs ***invariant***
* ***ru*** vs ***invariant***

Необходимо вывести на экране отличия в:

1) формат отображения даты и времени;
2) формат отображения числовых данных (разделитель дробной и целой части, разделитель групп разрядов и т.п.)

Целесообразно реализовать отдельный метод, который принимает на входе название культур и выводит отличия на экран. Повторно использовать этот метод (Code Reuse) для вывода различных пар культур.

### Задание 4

Проведите сравнительный анализ скорости работы классов **String** и **StringBuilder** для операции сложения:

```cs
int n = 100;

string str = "";
for (int i = 0; i < n; i++)
{
    str += "*";
}

var sb = new StringBuilder();
for (int i = 0; i < n; i++)
{
    sb.Append("*");
}
```

### Задание 5

Напишите программу, которая заменяет все найденные в тексте HTML теги на знак “_”. Обязательно использовать регулярные выражения.

Пример:

```html
Введите HTML текст: <b>Это</b> текст <i>с</i> <font color="red">HTML</font> кодами.
Результат замены: _Это_ текст _с_ _HTML_ кодами
```

### Задание 6

Напишите программу, которая проверяет текстовую строку на соответствие имеющегося в ней текста формату вещественного числа и выводит, в каком формате оно записано. Обязательно использовать регулярные выражения.

1. Число может быть записано в обычной нотации.
2. Число может быть записано в научной нотации (например, 127 = 1.27\*10^2 = 1.27e2, -0.0055 = -5.5\*10^-3 = -5.5e-3).

Пример:

```txt
Введите число: 5        — Это число в обычной нотации
Введите число: -2.5     — Это число в обычной нотации
Введите число: 5.75e-5  — Это число в научной нотации
Введите число: *        — Это не число
```

### Задание 7

Напишите программу, которая определяет, сколько раз в тексте встречается время. Постарайтесь учесть, что в сутках только 24 часа, а в часе — 60 минут. Обязательно использовать регулярные выражения.

Пример:

```txt
Введите текст: В 7:55 я встал, позавтракал и к 10:77 пошел на работу.
Время в тексте присутствует 1 раз.
```