using Marten.Schema;

namespace DotnetShop.Catalog.API
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();

            if (await session.Query<Product>().AnyAsync())
            {
                return;
            }

            session.Store(GetSampleProducts());
            await session.SaveChangesAsync();
        }

        private IEnumerable<Product> GetSampleProducts()
        {
            return new List<Product> {
                new Product
                {
                    Id = new Guid("28d65b5d-f522-448c-8ce5-203e4efe2c17"),
                    Name = "Kudu Purple Sweatshirt",
                    Price = 15.95M,
                    ShortDescription = "Our famous shirt!",
                    LongDescription =
                        "The Kudu Purple Sweatshirt blends style and comfort in a unique, eye-catching design. Crafted from a soft, high-quality cotton blend, this sweatshirt provides a relaxed fit that’s perfect for everything from coding marathons to weekend hangouts. The rich purple hue is both bold and subtle, making it an easy yet standout piece in any wardrobe. Featuring the Kudu logo, a nod to the powerful Azure App Service, it’s a must-have for developers, tech enthusiasts, or anyone with a passion for cloud computing. With ribbed cuffs and waistband for a snug, cozy fit, this sweatshirt keeps you warm and stylish no matter where you go. Show off your tech pride in ultimate comfort with the Kudu Purple Sweatshirt.",
                    Categories = ["Shirt"],
                    ImageUrl = "/images/Products/Kudu Purple Sweatshirt HD.png",
                    ImageThumbnailUrl = "/images/Products/Kudu Purple Sweatshirt.png",
                },
                new Product
                {
                    Id = new Guid("51149bd0-c9e0-4068-b8f2-3368caa5c85c"),
                    Name = ".NET Blue Sweatshirt",
                    Price = 18.95M,
                    ShortDescription = "You'll love it!",
                    LongDescription =
                        "The .NET Blue Sweatshirt is a stylish and comfortable addition to any developer's wardrobe. Made from a soft, premium cotton blend, this sweatshirt offers a cozy fit perfect for casual outings or cozying up during coding sessions. The bold blue color is complemented by the subtle yet distinctive .NET logo, representing your passion for technology and development. Featuring ribbed cuffs and a ribbed waistband for a snug fit, it ensures warmth without sacrificing mobility. Whether you're working late or relaxing on the weekend, this sweatshirt is the perfect way to showcase your love for the .NET ecosystem while staying comfortable.",
                    Categories = ["Shirt"],
                    ImageUrl = "/images/Products/NET Blue Sweatshirt HD.png",
                    ImageThumbnailUrl = "/images/Products/NET Blue Sweatshirt.png"
                },
                new Product
                {
                    Id = new Guid("5df4c8d9-77ba-469a-8a23-5b87f9f7d9c5"),
                    Name = ".NET Bot Black Sweatshirt",
                    Price = 18.95M,
                    ShortDescription = "Best seller in year.",
                    LongDescription =
                        "The .NET Bot Black Sweatshirt is the perfect blend of sleek design and comfort, ideal for developers and tech enthusiasts alike. Featuring a bold, minimalist graphic of the .NET Bot, this sweatshirt brings a fun and modern twist to your casual wardrobe. Made from a soft, premium cotton blend, it offers warmth and comfort for long coding sessions, weekend relaxation, or casual meetups. The timeless black color pairs easily with any outfit, while ribbed cuffs and waistband provide a snug fit to keep you cozy all day long. Whether you're showcasing your .NET pride or simply enjoying a laid-back day, the .NET Bot Black Sweatshirt is a stylish, tech-inspired essential.",
                    Categories = ["Shirt"],
                    ImageUrl = "/images/Products/NET Bot Black Sweatshirt HD.png",
                    ImageThumbnailUrl = "/images/Products/NET Bot Black Sweatshirt.png"
                },
                new Product
                {
                    Id = new Guid("293d91cd-0de8-4b18-b2e9-a1a26678dada"),
                    Name = ".NET Foundation Sweatshirt",
                    Price = 17.95M,
                    ShortDescription = "A summer classic!",
                    LongDescription =
                        "Stay cozy and show your support for the .NET ecosystem with this stylish .NET Foundation Sweatshirt. Crafted from a soft, high-quality blend of cotton and polyester, it offers the perfect balance of comfort and durability. The sleek, modern design features the iconic .NET Foundation logo, making it a great way to represent the open-source community while staying warm. Whether you're coding late into the night or just relaxing with friends, this sweatshirt is a must-have for any .NET enthusiast. Available in a variety of sizes and colors, it’s a versatile piece that’s perfect for everyday wear.",
                    Categories = ["Shirt"],
                    ImageUrl = "/images/Products/NET Foundation Sweatshirt HD.png",
                    ImageThumbnailUrl = "/images/Products/NET Foundation Sweatshirt.png"
                },
                new Product
                {
                    Id = new Guid("ad237f2f-94ce-46f5-91e5-950d328922a3"),
                    Name = "Prism White T-Shirt",
                    Price = 18.95M,
                    ShortDescription = "Welcome summer!",
                    LongDescription =
                        "The Prism White T-Shirt combines simplicity and style for an effortless, everyday look. Made from premium soft cotton, this classic white tee offers a comfortable, breathable fit that’s perfect for any occasion. Its clean, minimalist design features a subtle, yet striking logo or graphic (depending on the style), making it a versatile wardrobe staple. Whether you're layering it under a jacket, pairing it with jeans, or wearing it on its own, the Prism White T-Shirt brings a fresh, crisp look to any outfit. Ideal for casual outings, tech meetups, or just relaxing at home, this t-shirt is designed to offer both comfort and a touch of modern flair.",
                    Categories = ["Shirt"],
                    ImageUrl = "/images/Products/Prism White T-Shirt HD.png",
                    ImageThumbnailUrl = "/images/Products/Prism White T-Shirt.png"
                },
                new Product
                {
                    Id = new Guid("035cea53-40e4-4100-8a92-3d478342090c"),
                    Name = "Roslyn Red T-Shirt",
                    Price = 17.95M,
                    ShortDescription = "A summer favorite.",
                    LongDescription =
                        "The Roslyn Red T-Shirt is a bold and vibrant addition to your wardrobe, inspired by the energy of the Roslyn compiler platform. Made from a soft, high-quality cotton blend, this t-shirt offers a comfortable, breathable fit that feels great all day long. The rich, deep red hue gives it a distinctive, eye-catching appeal, while the minimalist design ensures it pairs effortlessly with jeans, shorts, or casual jackets. Whether you’re coding, hanging out with friends, or attending a tech event, the Roslyn Red T-Shirt is a versatile and stylish way to show off your passion for software development. With its premium fabric and modern fit, it’s as durable as it is stylish, making it a go-to piece for both work and play.",
                    Categories = ["Shirt"],
                    ImageUrl = "/images/Products/Roslyn Red T-Shirt HD.png",
                    ImageThumbnailUrl = "/images/Products/Roslyn Red T-Shirt.png"
                },
                new Product
                {
                    Id = new Guid("722baa3a-5cf7-4952-9cda-dfaa1ad1367f"),
                    Name = "Cup<T> T-Shirt",
                    Price = 19.95M,
                    ShortDescription = "Simple the best!",
                    LongDescription =
                        "The Cup<T> T-Shirt is the perfect choice for developers who love to blend their passion for code with their personal style. Inspired by the powerful world of generics in C#, this shirt features a clever graphic showcasing the \"Cup<T>\" template, making it a must-have for any programmer. Made from a soft, high-quality cotton blend, it offers all-day comfort while providing a modern, tailored fit. Whether you're at a hackathon, a coding meetup, or just relaxing at home, this t-shirt is a great conversation starter and a subtle nod to the power of generic types in programming. Available in a variety of sizes, the Cup<T> T-Shirt combines tech-savvy appeal with laid-back style, making it an ideal choice for every .NET enthusiast and software developer.",
                    Categories = ["Cup"],
                    ImageUrl = "/images/Products/CupT T-Shirt HD.png",
                },
                new Product
                {
                    Id = new Guid("a8814752-c866-4944-8020-61279d380087"),
                    Name = "Cup<T> White Mug",
                    Price = 10.95M,
                    ShortDescription = "A new designed cup.",
                    LongDescription =
                        "The Cup<T> White Mug is a must-have for any developer who appreciates the finer details of coding—and coffee. With a sleek, minimalist design, this 11oz ceramic mug features the iconic Cup<T> graphic, a nod to the versatility of generics in C# programming. Its smooth, glossy white finish makes it a stylish addition to your desk, while the comfortable handle and durable construction ensure it’s perfect for sipping your favorite hot beverages. Whether you’re fueling a late-night coding session or enjoying a morning break, this mug is the perfect way to add a touch of techie flair to your routine. A great gift for developers and .NET enthusiasts, the Cup<T> White Mug combines functionality with geeky charm—because every coder deserves a mug that’s as clever as their code.",
                    Categories = ["Cup"],
                    ImageUrl = "/images/Products/CupT White Mug HD.png",
                    ImageThumbnailUrl = "/images/Products/CupT White Mug.png"
                },
                new Product
                {
                    Id = new Guid("03eb5b7c-3e42-4361-8210-3cb6ce0cf88f"),
                    Name = ".NET Black White Mug",
                    Price = 10.95M,
                    ShortDescription = "A classic designed cup.",
                    LongDescription =
                        "The .NET Black & White Mug is a sleek and stylish way to enjoy your favorite drinks while representing the world of .NET development. Featuring a bold black exterior with a contrasting white .NET logo, this 11oz ceramic mug offers a modern, minimalist design that stands out on any desk. The smooth finish and comfortable handle make it perfect for sipping coffee, tea, or any hot beverage during those long coding sessions. Whether you're a .NET enthusiast or simply love clean, sophisticated designs, this mug adds a touch of tech-inspired elegance to your daily routine. A great gift for developers, it's both functional and a subtle nod to the .NET ecosystem.",
                    Categories = ["Cup"],
                    ImageUrl = "/images/Products/NET Black White Mug HD.png",
                    ImageThumbnailUrl = "/images/Products/NET Black White Mug.png"
                },
                new Product
                {
                    Id = new Guid("4ae642de-3ccf-4bca-8c24-14ae508a759f"),
                    Name = "Cup<T> Badge",
                    Price = 4.95M,
                    ShortDescription = "A geeky badge!",
                    LongDescription =
                        "The Cup<T> Badge is the perfect accessory for developers who appreciate both clever coding concepts and stylish flair. Featuring the iconic **Cup<T>** graphic, this badge is a playful nod to the power of generics in C#. Whether you’re adding it to your laptop bag, jacket, or lanyard, this small but impactful pin is a great way to show off your love for coding and your .NET expertise. Crafted from durable materials with a secure backing, the **Cup<T> Badge** is designed to last through every project and tech event. A must-have for every developer’s collection, it’s a fun and subtle way to wear your coding passion on your sleeve—literally!",
                    Categories = ["Badge"],
                    ImageUrl = "/images/Products/CupT Badge HD.png",
                    ImageThumbnailUrl = "/images/Products/CupT Badge.png"
                },
                new Product
                {
                    Id = new Guid("90e3af6d-e79a-45b6-b2c8-8bc25f60708a"),
                    Name = "NET Foundation Badge",
                    Price = 3.95M,
                    ShortDescription = "You'll love it!",
                    LongDescription =
                        "The .NET Foundation Badge is a stylish and meaningful way to show your support for the .NET open-source community. Featuring the iconic .NET Foundation logo, this sleek, high-quality badge is the perfect accessory for any developer passionate about the .NET ecosystem. Whether you pin it to your backpack, jacket, or conference lanyard, this badge serves as a subtle yet powerful symbol of your commitment to collaboration, innovation, and the open-source movement. Crafted from durable materials with a secure backing, the **.NET Foundation Badge** is both lightweight and long-lasting, making it an ideal way to proudly represent your involvement in the .NET community wherever you go. Perfect for meetups, hackathons, and casual wear, this badge is a must-have for any .NET enthusiast.",
                    Categories = ["Badge"],
                    ImageUrl = "/images/Products/NET Foundation Badge HD.png",
                    ImageThumbnailUrl = "/images/Products/NET Foundation Badge.png"
                },
                new Product
                {
                    Id = new Guid("324a1f34-97f9-4636-be93-ec456b19f90e"),
                    Name = "Roslyn Red Badge",
                    Price = 3.95M,
                    ShortDescription = "You'll love it!",
                    LongDescription =
                        "The Roslyn Red Badge is a bold and vibrant way to showcase your passion for C# and the Roslyn compiler platform. Featuring a striking red design and a sleek, minimalist graphic, this badge is a perfect representation of your love for modern software development. Whether you’re attending a tech meetup, coding event, or simply want to add some personality to your gear, the **Roslyn Red Badge** makes a stylish statement. Crafted from high-quality materials with a secure pin backing, it’s built to last and can easily be attached to your bag, jacket, or lanyard. Show off your Roslyn pride and stand out in the developer community with this eye-catching, tech-inspired accessory.",
                    Categories = ["Badge"],
                    ImageUrl = "/images/Products/Roslyn Red Badge HD.png",
                    ImageThumbnailUrl = "/images/Products/Roslyn Red Badge.png"
                }
            };
        }
    }
}
