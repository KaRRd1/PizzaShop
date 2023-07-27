using Domain.Entities;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Type = Domain.Entities.Type;

namespace Infrastructure.Data;

public class ShopDbInitializer
{
    private readonly ShopDbContext _context;

    public ShopDbInitializer(ShopDbContext context)
    {
        _context = context;
    }

    public async Task InitializeAsync()
    {
        await _context.Database.MigrateAsync();
    }

    public async Task SeedAsync()
    {
        if (!_context.OrderStatuses.Any())
        {
            _context.OrderStatuses.AddRange(GetPreconfiguredOrderStatuses());
            await _context.SaveChangesAsync();
        }
        if (!_context.Roles.Any())
        {
            _context.Roles.AddRange(GetPreconfiguredRoles());
            await _context.SaveChangesAsync();
        }

        if (!_context.Units.Any())
        {
            _context.Units.AddRange(GetPreconfiguredUnits());
            await _context.SaveChangesAsync();
        }

        if (!_context.Sizes.Any())
        {
            _context.Sizes.AddRange(GetPreconfiguredSizes());
            await _context.SaveChangesAsync();
        }

        if (!_context.Types.Any())
        {
            _context.Types.AddRange(GetPreconfiguredTypes());
            await _context.SaveChangesAsync();
        }
        
        if (!_context.Categories.Any())
        {
            _context.Categories.AddRange(GetPreconfiguredCategories());
            await _context.SaveChangesAsync();
        }

        if (!_context.IngredientCategories.Any())
        {
            _context.IngredientCategories.AddRange(GetPreconfiguredIngredientCategories());
            await _context.SaveChangesAsync();
        }

        if (!_context.Ingredients.Any())
        {
            _context.Ingredients.AddRange(GetPreconfiguredIngredients());
            await _context.SaveChangesAsync();
        }

        if (!_context.Products.Any())
        {
            _context.Products.AddRange(GetPreconfiguredProducts());
            await _context.SaveChangesAsync();
        }


        if (!_context.PaymentMethods.Any())
        {
            _context.PaymentMethods.AddRange(GetPreconfiguredPaymentMethods());
            await _context.SaveChangesAsync();
        }
    }

    private List<OrderStatus> GetPreconfiguredOrderStatuses()
    {
        var statuses = new List<OrderStatus>()
        {
            new() { Name = "Создан" },
            new() { Name = "Готовится" },
            new() { Name = "Доставляется" },
            new() { Name = "Выполнен"}
        };
        
        return statuses;
    }
    
    private List<Role> GetPreconfiguredRoles()
    {
        var roles = new List<Role>
        {
            new() { Name = "Admin" },
            new() { Name = "Client" },
        };

        return roles;
    }

    private List<User> GetPreconfiguredUsers()
    {
        var users = new List<User>
        {
            new() { Phone = "+7 (938) 528-45-61", Name = "Администратор", RoleId = 1 },
        };

        return users;
    }

    private List<PaymentMethod> GetPreconfiguredPaymentMethods()
    {
        var paymentMethods = new List<PaymentMethod>
        {
            new() { Name = "Карта" },
            new() { Name = "Наличные" },
        };

        return paymentMethods;
    }

    private List<Type> GetPreconfiguredTypes()
    {
        var types = new List<Type>
        {
            new() { Name = "Традиционное" },
            new() { Name = "Тонкое" }
        };
        return types;
    }

    private List<Unit> GetPreconfiguredUnits()
    {
        var units = new List<Unit>
        {
            new() { Name = "см" },
            new() { Name = "шт" },
            new() { Name = "л" }
        };

        return units;
    }

    private List<Size> GetPreconfiguredSizes()
    {
        var sizes = new List<Size>
        {
            new() { UnitId = 1, Value = 20 },
            new() { UnitId = 1, Value = 25 },
            new() { UnitId = 1, Value = 30 },
            new() { UnitId = 2, Value = 6 },
            new() { UnitId = 2, Value = 8 },
            new() { UnitId = 2, Value = 3 },
            new() { UnitId = 2, Value = 9 },
            new() { UnitId = 2, Value = 12 },
            new() { UnitId = 2, Value = 1 },
            new() { UnitId = 3, Value = 0.5 },
            new() { UnitId = 3, Value = 1 },
        };

        return sizes;
    }

    private List<Category> GetPreconfiguredCategories()
    {
        var categories = new List<Category>
        {
            new()
            {
                Name = "Пицца", Alias = "pizza", Position = 1,
                // Sizes = GetSizesByIds(new List<int> { 1, 2 ,3 }),
                // Types = GetTypesByIds(new List<int> { 1, 2 })
            },
            new()
            {
                Name = "Роллы", Alias = "rolls", Position = 2,
                // Sizes = GetSizesByIds(new List<int> { 4, 5 }),
            },
            new()
            {
                Name = "Напитки", Alias = "drinks", Position = 3,
                // Sizes = GetSizesByIds(new List<int> { 10, 11 }),
            },
            new()
            {
                Name = "Закуски", Alias = "snacks", Position = 4,
                // Sizes = GetSizesByIds(new List<int> { 6, 7, 8 }),
            },
            new() { 
                Name = "Соусы", Alias = "sauces", Position = 5, 
                // Sizes = GetSizesByIds(new List<int> { 9 }),
            },
            new() { 
                Name = "Десерты", Alias = "dessert", Position = 6, 
                // Sizes = GetSizesByIds(new List<int> { 9 }),
            },
        };

        return categories;
    }

    private List<Type> GetTypesByIds(List<int> ids)
    {
        return _context.Types.Where(type => ids.Contains(type.Id)).ToList();
    }
    
    private List<Size> GetSizesByIds(List<int> ids)
    {
        return _context.Sizes.Where(size => ids.Contains(size.Id)).ToList();
    }

    private List<IngredientCategory> GetPreconfiguredIngredientCategories()
    {
        var ingredientCategories = new List<IngredientCategory>
        {
            new() { Name = "Сыр" },
            new() { Name = "Мясо" },
            new() { Name = "Овощи" },
            new() { Name = "Бакалея" },
            new() { Name = "Соусы" },
        };

        return ingredientCategories;
    }

    private List<Ingredient> GetPreconfiguredIngredients()
    {
        var ingredients = new List<Ingredient>
        {
            new() { Name = "Сыр пармезан", IngredientCategoryId = 1 }, //1
            new() { Name = "Сыр чеддер", IngredientCategoryId = 1 }, //2
            new() { Name = "Сыр гарганзола", IngredientCategoryId = 1 }, //3
            new() { Name = "Пепперони", IngredientCategoryId = 2 }, //4
            new() { Name = "Ветчина", IngredientCategoryId = 2 }, //5
            new() { Name = "Цыплёнок", IngredientCategoryId = 2 }, //6
            new() { Name = "Охотничьи колбаски", IngredientCategoryId = 2 }, //6
            new() { Name = "Мидии", IngredientCategoryId = 2 }, //7
            new() { Name = "Бекон", IngredientCategoryId = 2 }, //8
            new() { Name = "Чоризо", IngredientCategoryId = 2 }, //9
            new() { Name = "Креветки", IngredientCategoryId = 2 }, //10
            new() { Name = "Лосось", IngredientCategoryId = 2 }, //10
            new() { Name = "Помидоры черри", IngredientCategoryId = 3 }, //11
            new() { Name = "Шампиньоны", IngredientCategoryId = 3 }, //12
            new() { Name = "Ананасы", IngredientCategoryId = 3 }, //13
            new() { Name = "Халапеньо", IngredientCategoryId = 3 }, //14
            new() { Name = "Маринованные огруцы", IngredientCategoryId = 3 }, //15
            new() { Name = "Айсберг", IngredientCategoryId = 3 }, //16
            new() { Name = "Лук красный", IngredientCategoryId = 3 }, //17
            new() { Name = "Болгарский перец", IngredientCategoryId = 3 }, //18
            new() { Name = "Маслины", IngredientCategoryId = 3 }, //19
            new() { Name = "Чеснок", IngredientCategoryId = 3 }, //20
            new() { Name = "Яйцо куриное", IngredientCategoryId = 4 }, //21
            new() { Name = "Соус барбекью", IngredientCategoryId = 5 }, //22
            new() { Name = "Соус песто", IngredientCategoryId = 5 }, //23
            new() { Name = "Соус унаги", IngredientCategoryId = 5 }, //24
        };

        return ingredients;
    }

    private List<Product> GetPreconfiguredProducts()
    {
        var products = new List<Product>
        {
            new()
            {
                Name = "Маргарита", Description = "Соус томатный, сыр моцарелла, помидоры",
                ImageSmallUrl = "/images/280x280/pizza_1.png", ImageLargeUrl = "/images/450x450/pizza_1.png",
                CategoryId = 1,
                Ingredients = IdsToModelList<Ingredient>(13).ToList(), Variations = GetPizzaVariations(289, 399, 549)
            },
            new()
            {
                Name = "Морская", Description = "Соус сливочный, сыр моцарелла, креветки, лосось, помидоры",
                ImageSmallUrl = "/images/280x280/pizza_2.png", ImageLargeUrl = "/images/450x450/pizza_2.png",
                CategoryId = 1,
                Ingredients = IdsToModelList<Ingredient>(11, 12, 13), Variations = GetPizzaVariations(419, 589, 789)
            },
            new()
            {
                Name = "Мясная",
                Description = "Соус томатный, сыр моцарелла, пепперони, ветчина, цыплёнок, бекон, охотничьи колбаски",
                ImageSmallUrl = "/images/280x280/pizza_3.png", ImageLargeUrl = "/images/450x450/pizza_3.png",
                CategoryId = 1,
                Ingredients = IdsToModelList<Ingredient>(4, 5, 7, 9), Variations = GetPizzaVariations(419, 599, 799)
            },
            new()
            {
                Name = "4 сыра", Description = "Соус томатный, сыр моцарелла, сыр пармезан, сыр чеддер, сыр дор блю",
                ImageSmallUrl = "/images/280x280/pizza_4.png", ImageLargeUrl = "/images/450x450/pizza_4.png",
                CategoryId = 1,
                Ingredients = IdsToModelList<Ingredient>(1, 2), Variations = GetPizzaVariations(399, 619, 909)
            },
            new()
            {
                Name = "Супер острая",
                Description =
                    "Томатный соус, шрирача, сыр моцарелла, халапеньо, лук красный, курица, пепперонни, соус барбекю",
                ImageSmallUrl = "/images/280x280/pizza_5.png", ImageLargeUrl = "/images/450x450/pizza_5.png",
                CategoryId = 1,
                Ingredients = IdsToModelList<Ingredient>(16, 24), Variations = GetPizzaVariations(379, 499, 699)
            },
            new()
            {
                Name = "Барбекю",
                Description = "Соус томатный, сыр моцарелла, цыплёнок, маринованные огурцы, соус барбекю",
                ImageSmallUrl = "/images/280x280/pizza_6.png", ImageLargeUrl = "/images/450x450/pizza_6.png",
                CategoryId = 1,
                Ingredients = IdsToModelList<Ingredient>(6, 17, 24), Variations = GetPizzaVariations(359, 479, 669)
            },
            new()
            {
                Name = "Филадельфия", Description = "Рис, нори, сыр филадельфия, лосось",
                ImageSmallUrl = "/images/280x280/roll_1.png", ImageLargeUrl = "/images/450x450/roll_1.png",
                CategoryId = 2,
                Variations = new List<ProductVariation>()
                {
                    new() { SizeId = 4, Price = 319, WeightGrams = 179 },
                    new() { SizeId = 5, Price = 479, WeightGrams = 222 }
                }
            },
            new()
            {
                Name = "Филадельфия Спайси", Description = "Рис, нори, сыр филадельфия, огурец, лосось, соус спайс",
                ImageSmallUrl = "/images/280x280/roll_2.png", ImageLargeUrl = "/images/450x450/roll_2.png",
                CategoryId = 2,
                Variations = new List<ProductVariation>
                {
                    new() { SizeId = 4, Price = 299, WeightGrams = 168 },
                    new() { SizeId = 5, Price = 489, WeightGrams = 212 }
                }
            },
            new()
            {
                Name = "Канада", Description = "Рис, нори, сыр филадельфия, огурец, угорь, соус унаги, кунжут",
                ImageSmallUrl = "/images/280x280/roll_5.png", ImageLargeUrl = "/images/450x450/roll_5.png",
                CategoryId = 2,
                Variations = new List<ProductVariation>
                {
                    new() { SizeId = 4, Price = 289, WeightGrams = 190 },
                    new() { SizeId = 5, Price = 479, WeightGrams = 242 }
                }
            },
            new()
            {
                Name = "Запечённая Калифорния",
                Description = "Рис, нори, снежный краб, авокадо, икра масаго, соус розовый",
                ImageSmallUrl = "/images/280x280/roll_3.png", ImageLargeUrl = "/images/450x450/roll_3.png",
                CategoryId = 2,
                Variations = new List<ProductVariation>
                {
                    new() { SizeId = 4, Price = 269, WeightGrams = 183 },
                    new() { SizeId = 5, Price = 459, WeightGrams = 230 }
                }
            },
            new()
            {
                Name = "Бонсай Темпура",
                Description = "Рис, нори, сыр филадельфия, угорь, авокадо, панировка, соус унаги, соус спайс",
                ImageSmallUrl = "/images/280x280/roll_4.png", ImageLargeUrl = "/images/450x450/roll_4.png",
                CategoryId = 2,
                Variations = new List<ProductVariation>
                {
                    new() { SizeId = 4, Price = 289, WeightGrams = 186 },
                    new() { SizeId = 5, Price = 469, WeightGrams = 235 }
                }
            },
            new()
            {
                Name = "Наггетсы", Description = "Куриные наггетсы", ImageSmallUrl = "/images/280x280/snacks_1.png",
                ImageLargeUrl = "/images/450x450/snacks_1.png", CategoryId = 4,
                Variations = new List<ProductVariation>
                {
                    new() { SizeId = 6, Price = 99 }, new() { SizeId = 4, Price = 189 },
                    new() { SizeId = 7, Price = 279 }
                }
            },
            new()
            {
                Name = "Картофель фри с соусом", Description = "Картофель фри с томатным соусом Heinze",
                ImageSmallUrl = "/images/280x280/snacks_2.png",
                ImageLargeUrl = "/images/450x450/snacks_2.png", CategoryId = 4,
                Variations = new List<ProductVariation> { new() { SizeId = 9, Price = 189 } }
            },
            new()
            {
                Name = "Сырные палочки", Description = "Сырные палочки собственного приготовления",
                ImageSmallUrl = "/images/280x280/snacks_3.png",
                ImageLargeUrl = "/images/450x450/snacks_3.png", CategoryId = 4,
                Variations = new List<ProductVariation>
                    { new() { SizeId = 4, Price = 229 }, new() { SizeId = 8, Price = 399 } }
            },
            new()
            {
                Name = "Соус сырный", Description = "Соус сырный Heinz", ImageSmallUrl = "/images/280x280/sauce_1.png",
                ImageLargeUrl = "/images/450x450/sauce_1.png", CategoryId = 5,
                Variations = new List<ProductVariation> { new() { SizeId = 9, Price = 39 } }
            },
            new()
            {
                Name = "Томатный кетчуп", Description = "Томатный кетчуп Heinz",
                ImageSmallUrl = "/images/280x280/sauce_2.png",
                ImageLargeUrl = "/images/450x450/sauce_2.png", CategoryId = 5,
                Variations = new List<ProductVariation> { new() { SizeId = 9, Price = 39 } }
            },
            new()
            {
                Name = "Добрый Кола", Description = "Газированный напиток кола",
                ImageSmallUrl = "/images/280x280/drinks_1.png",
                ImageLargeUrl = "/images/450x450/drinks_1.png", CategoryId = 3,
                Variations = new List<ProductVariation>
                    { new() { SizeId = 10, Price = 99 }, new() { SizeId = 11, Price = 179 } }
            },
            new()
            {
                Name = "Добрый Апельсин", Description = "Газированный напиток Добрый со вкусом апельсина",
                ImageSmallUrl = "/images/280x280/drinks_2.png",
                ImageLargeUrl = "/images/450x450/drinks_2.png", CategoryId = 3,
                Variations = new List<ProductVariation>
                    { new() { SizeId = 10, Price = 99 }, new() { SizeId = 11, Price = 179 } }
            },
            new()
            {
                Name = "Шоколадный фондан", Description = "Горячий шоколад в нежном бисквите",
                ImageSmallUrl = "/images/280x280/dessert_1.png",
                ImageLargeUrl = "/images/450x450/dessert_1.png", CategoryId = 6,
                Variations = new List<ProductVariation> { new() { SizeId = 9, Price = 199 } }
            },
            new()
            {
                Name = "Чизкейк Нью-Йорк", Description = "Классический чизкейк - Нью-Йорк",
                ImageSmallUrl = "/images/280x280/dessert_2.png",
                ImageLargeUrl = "/images/450x450/dessert_2.png", CategoryId = 6,
                Variations = new List<ProductVariation> { new() { SizeId = 9, Price = 139 } }
            },
        };
        return products;
    }

    private List<ProductVariation> GetPizzaVariations(int price20Cm, int price25Cm, int price30Cm)
    {
        var pizzaVariations = new List<ProductVariation>();
        var prices = new[] { price20Cm, price25Cm, price30Cm };
        var sizes = IdsToModelList<Size>(1, 2, 3);
        var types = IdsToModelList<Type>(1, 2);

        for (int i = 0; i < sizes.Count; i++)
        {
            pizzaVariations.Add(new() { Size = sizes[i], Price = prices[i], Type = types[0] });
            pizzaVariations.Add(new() { Size = sizes[i], Price = prices[i] - 10, Type = types[1] });
        }

        return pizzaVariations;
    }

    private List<ProductVariation> GetRollVariations(int price6Amount, int price8Amount)
    {
        var sizes = IdsToModelList<Size>(4, 5);

        return new List<ProductVariation>()
        {
            new() { Size = sizes[0], Price = price6Amount },
            new() { Size = sizes[1], Price = price8Amount }
        };
    }

    private List<T> IdsToModelList<T>(params int[] ids) where T : BaseEntity
    {
        return _context.Set<T>().Where(x => ids.Contains(x.Id)).ToList();
    }
}