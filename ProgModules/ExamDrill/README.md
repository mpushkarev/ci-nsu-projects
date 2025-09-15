# 🔥 Спидран экзамена (и не только)

> Motto: Ship it, don't perfect it 🚀

В этом разделе собраны минимально необходимые знания и некоторые шаблоны для быстрого создания WPF-приложения с базой данных за ограниченное время. Фокус на скорость выполнения, а не на архитектурную красоту, по последней сделано много допущений и упрощений.

## ⚡ Первые 30 минут - Это База

### 🗂️ Создаем WPF проект + SQLite

В Visual Studio создаем новый проект `Приложение WPF (Майкрософт)`.

![Начальный экран проекта](misc/images/wpf_first_step.jpg)

Устанавливаем `Microsoft.EntityFrameworkCore.Sqlite`, для этого открываем `Проект > Управление пакетами NuGet...`. Или, что проще, можно открыть терминал (`ПКМ на проект > Открыть в терминале`) и там выполнить:

```ps
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
```

### 📝 Модели данных (классы)

Создаем примерно такую структуру в проекте:

```tree
ExamDrillDemo/
├── Models/
│   ├── Item.cs
│   ├── Category.cs
│   ├── Note.cs
│   ├── Tag.cs
│   └── ItemTag.cs
├── Data/
│   └── AppDbContext.cs
├── MainWindow.xaml
```

Здесь представлен абстрактный пример, покрывающий основные варианты.

В каждой модели примерно такое содержание:

**Item.cs**

| Id       | Name   | CategoryId |
|----------|--------|------------|
| int (PK) | string | int (FK)   |

```csharp
public class Item {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public List<Note>? Notes { get; set; }
    public List<ItemTag>? ItemTags { get; set; }
}
```

**Category.cs**

| Id       | Title  |
|----------|--------|
| int (PK) | string |

```csharp
public class Category {
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public List<Item>? Items { get; set; }
}
```

**Note.cs**

| Id       | Text   | ItemId   |
|----------|--------|----------|
| int (PK) | string | int (FK) |

```csharp
public class Note {
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public int ItemId { get; set; }
    public Item? Item { get; set; }
}
```

**Tag.cs**

| Id       | Name   |
|----------|--------|
| int (PK) | string |

```csharp
public class Tag {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<ItemTag>? ItemTags { get; set; }
}
```

**ItemTag.cs**

| Id       | ItemId   | TagId    |
|----------|----------|----------|
| int (PK) | int (FK) | int (FK) |

```csharp
public class ItemTag {
    public int Id { get; set; }
    public int ItemId { get; set; }
    public Item? Item { get; set; }
    public int TagId { get; set; }
    public Tag? Tag { get; set; }
}
```

По большей части все относительно понятно, но чуть подробнее про некоторые моменты.

1. Использование `nullable` для навигационных свойств, чтобы не вызывать предупреждения. Это защищает от ситуации, когда связь отсутствует.
2. Для решения проблем с инициализацией строки юзаем `= string.Empty`. Это сахар, заменяющий инициализацию строки в конструкторе.
3. На этом этапе пока что только просто модели данных! Не заморачиваемся с авторизацией и ролями, это позже.

<details>
<summary>⁉️ А что в итоге будет?</summary>

Для пользователя в дальнейшем все будет примерно вот так:

**Items:**

| Id | Name  | Category | Notes      | Tags              |
|----|-------|----------|------------|-------------------|
| 1  | aboba | abobus   | haha, ohoh | lol, kek, 4eburek |

**Tags:**

| Id | Name    |
|----|---------|
| 1  | lol     |
| 2  | kek     |
| 3  | 4eburek |

**Notes:**

| Id | Text  | Item         |
|----|-------|--------------|
| 1  | haha  | aboba (Id 1) |
| 2  | ohoh  | aboba (Id 1) |

</details>
