using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        private readonly List<Guid> _roleIds;

        public RoleConfig(List<Guid> roleIds)
        {
            _roleIds = roleIds;
        }

        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Name)
                .HasColumnName("Role_Name")
                .HasColumnType("nvarchar(240)");

            builder.Property(r => r.NormalizedName)
                .HasColumnName("NormalizedRole_Name")
                .HasColumnType("nvarchar(240)");

            builder.Property(r => r.ConcurrencyStamp)
                .HasDefaultValueSql("NEWID()")
                .ValueGeneratedOnAddOrUpdate();

            builder.Property(r => r.Buyer)
                 .HasColumnName("Buyer")
                 .HasColumnType("bit");

            builder.Property(r => r.Analitics)
                 .HasColumnName("Analitics")
                 .HasColumnType("bit");

            builder.Property(r => r.PreAcceptancePC)
                 .HasColumnName("PreAcceptance_PC")
                 .HasColumnType("bit");

            builder.Property(r => r.PreAcceptanceHand)
                .HasColumnName("PreAcceptance_Hand")
                .HasColumnType("bit");

            builder.Property(r => r.AcceptancePC)
                .HasColumnName("Acceptance_PC")
                .HasColumnType("bit");

            builder.Property(r => r.AcceptanceHand)
                .HasColumnName("Acceptance_Hand")
                .HasColumnType("bit");

            builder.Property(r => r.ShipmentBagPC)
                .HasColumnName("Shipment_Bag_PC")
                .HasColumnType("bit");

            builder.Property(r => r.ShipmentBagHand)
                .HasColumnName("Shipment_Bag_Hand")
                .HasColumnType("bit");

            builder.Property(r => r.PickingPC)
                .HasColumnName("Picking_PC")
                .HasColumnType("bit");

            builder.Property(r => r.PickingHand)
                .HasColumnName("Picking_Hand")
                .HasColumnType("bit");

            builder.Property(r => r.CarriagePC)
                .HasColumnName("Carriage_PC")
                .HasColumnType("bit");

            builder.Property(r => r.CarriageHand)
                .HasColumnName("Carriage_Hand")
                .HasColumnType("bit");

            builder.Property(r => r.Reports)
                .HasColumnName("Reports")
                .HasColumnType("bit");

            builder.Property(r => r.Parameters)
                .HasColumnName("Parameters")
                .HasColumnType("bit");

            List<string> roleNames = ["Admin", "Purchaser", "Supplier", "User"];
            List<Role> roles = [];
            for (int i = 0; i < _roleIds.Count; i++)
            {
                roles.Add(new Role
                {
                    Id = _roleIds[i],
                    Name = roleNames[i],
                    NormalizedName = roleNames[i].ToUpper(),
                    Buyer = false,
                    Analitics = false,
                    PreAcceptancePC = false,
                    PreAcceptanceHand = false,
                    AcceptancePC = false,
                    AcceptanceHand = false,
                    ShipmentBagPC = false,
                    ShipmentBagHand = false,
                    PickingPC = false,
                    PickingHand = false,
                    CarriagePC = false,
                    CarriageHand = false,
                    Reports = false,
                    Parameters = false
                });
            }
            builder.HasData(roles);
        }
    }
}
