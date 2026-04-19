[README.md](https://github.com/user-attachments/files/26871431/README.md)
# 🍽️ Каталог за Готварски Рецепти

Курсов проект по ** програмиране** — ASP.NET Core 8 MVC уеб приложение.

---

## 📋 Описание

Уеб приложение за каталогизиране на готварски рецепти с пълна CRUD функционалност, система за регистрация и роли (Потребител / Администратор), коментари и одобрение на рецепти.

---

## 🏗️ Архитектура (3 слоя)

```
RecipeCatalog.sln
├── RecipeCatalog.Data        ← Слой за данни (EF Core, модели, DbContext)
├── RecipeCatalog.Services    ← Слой за услуги (бизнес логика, интерфейси, DTOs)
├── RecipeCatalog.Web         ← Презентационен слой (MVC Controllers + Views)
└── RecipeCatalog.Tests       ← Компонентни тестове (xUnit + InMemory DB)
```

---

## 🗃️ Модели данни (Entities)

| Модел | Описание |
|-------|----------|
| `Recipe` | Рецепта с заглавие, инструкции, трудност |
| `Category` | Категория (Супи, Десерти и др.) |
| `Ingredient` | Съставка с мерна единица |
| `RecipeIngredient` | **Много-към-много**: Рецепта ↔ Съставка |
| `RecipeCategory` | **Много-към-много**: Рецепта ↔ Категория |
| `Comment` | Коментар към рецепта |
| `ApplicationUser` | Потребител (разширен IdentityUser) |

---

## 🔐 Роли и достъп

| Функционалност | Гост | Потребител | Администратор |
|---|:---:|:---:|:---:|
| Разглеждане на рецепти | ✅ | ✅ | ✅ |
| Добавяне на рецепта | ❌ | ✅ | ✅ |
| Редактиране на своя рецепта | ❌ | ✅ | ✅ |
| Коментиране | ❌ | ✅ | ✅ |
| Одобрение на рецепти | ❌ | ❌ | ✅ |
| Управление на категории | ❌ | ❌ | ✅ |
| Управление на съставки | ❌ | ❌ | ✅ |

---

## 🚀 Стартиране (Visual Studio)

### Предварителни изисквания
- **Visual Studio 2022** (17.8+)
- **.NET 8 SDK**
- **SQL Server LocalDB** (идва с Visual Studio)

### Стъпки

1. **Отвори решението** — двойно кликни върху `RecipeCatalog.sln`

2. **Задай стартов проект** — десен клик върху `RecipeCatalog.Web` → *Set as Startup Project*

3. **Приложи миграциите** — отвори *Package Manager Console* (Tools → NuGet → PMC):
   ```powershell
   # В PMC, избери RecipeCatalog.Web като Default Project
   Add-Migration InitialCreate -Project RecipeCatalog.Data -StartupProject RecipeCatalog.Web
   Update-Database -Project RecipeCatalog.Data -StartupProject RecipeCatalog.Web
   ```
   > Алтернативно от терминала: `dotnet ef database update --project RecipeCatalog.Data --startup-project RecipeCatalog.Web`

4. **Стартирай** — натисни **F5** или бутона ▶️

### Администраторски акаунт (автоматично създаден)
- **Email:** `admin@recipes.bg`
- **Парола:** `Admin123!`

---

## 🧪 Тестове

```powershell
# От Package Manager Console или терминал
dotnet test RecipeCatalog.Tests
```

Тестовете покриват:
- `RecipeService` — GetAll, Create, Delete, Approve, IsAuthor, AddComment
- `CategoryService` — GetAll, GetById, Create, Delete

---

## 📁 Структура на проекта

```
RecipeCatalog.Web/
├── Controllers/
│   ├── HomeController.cs
│   ├── RecipeController.cs   ← CRUD за рецепти
│   └── AdminController.cs    ← Админ панел
├── Views/
│   ├── Home/Index.cshtml
│   ├── Recipe/{Index, Details, Create, Edit}.cshtml
│   ├── Admin/{Index, Categories, Ingredients, ...}.cshtml
│   └── Shared/{_Layout, _RecipeCard, _ValidationScripts}.cshtml
└── wwwroot/{css, js}/

RecipeCatalog.Services/
├── Interfaces/{IRecipeService, ICategoryService, IIngredientService}.cs
├── Implementations/{RecipeService, CategoryAndIngredientService}.cs
└── DTOs/RecipeDtos.cs

RecipeCatalog.Data/
├── Models/{Recipe, Category, Ingredient, RecipeIngredient, RecipeCategory, Comment, ApplicationUser}.cs
└── ApplicationDbContext.cs
```

---

## 🛠️ Технологии

- **ASP.NET Core 8 MVC**
- **Entity Framework Core 8** (ORM)
- **ASP.NET Identity** (автентикация и роли)
- **SQL Server LocalDB**
- **Bootstrap 5.3** + **Font Awesome 6**
- **xUnit** + **Moq** (тестове)

---

*Разработено за Национална програма "Обучение за ИТ умения и кариера" — МОН*
