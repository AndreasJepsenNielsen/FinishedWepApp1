namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0ee3b078-9c8e-4a4a-ab99-4d6b85c8a577', N'guest@guest.com', 0, N'AOf26unzGsKyaPG6xlb5h7XoLwALzzoXS+s5JBZzVH7VYb7e6duLX252yV0YYPwp4A==', N'15f47fd7-5f87-4246-aca2-34c423c5ca55', NULL, 0, 0, NULL, 1, 0, N'guest@guest.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'af7d4da7-75fa-4266-8321-91fb4b2cd35a', N'Admin@Admin.com', 0, N'ABpLSXU752KF3xWYFJvuCYEgPxgJZmf4YsUzMSLRpsXNvatttWAJZi2sR7e0U/wyOg==', N'fa5907f9-a2fa-43b5-bae1-e63fb489b0e7', NULL, 0, 0, NULL, 1, 0, N'Admin@Admin.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'fde78749-586f-4658-95ed-184782c51f58', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'af7d4da7-75fa-4266-8321-91fb4b2cd35a', N'fde78749-586f-4658-95ed-184782c51f58')

");
        }
        
        public override void Down()
        {
        }
    }
}
