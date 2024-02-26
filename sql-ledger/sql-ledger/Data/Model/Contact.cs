using Microsoft.EntityFrameworkCore;

namespace sql_ledger.Data.Model
{
    public class Contact
    {
        public int Id { get; set; }
        public int TransId { get; set; }
        public string? Salutation { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ContactTitle { get; set; }
        public string? Occupation { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public char Gender { get; set; }
        public int? ParentId { get; set; }
        public string? TypeOfContact { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            _builder.HasSequence<int>("contact_id")
                .StartsAt(1)
                .IncrementsBy(1);

            var ent = _builder.Entity<Contact>();

            ent.HasKey(x => x.Id).HasName("contact_pkey");
            ent.ToTable("contact");

            ent.Property(x => x.Id).HasColumnName("id")
                .HasDefaultValueSql<int>("NEXT VALUE FOR contact_id");
            ent.Property(x => x.TransId).HasColumnName("trans_id");
            ent.Property(x => x.Salutation).HasColumnName("salutation")
                .HasColumnType("nvarchar(32)");
            ent.Property(x => x.FirstName).HasColumnName("firstname")
                .HasColumnType("nvarchar(32)");
            ent.Property(x => x.LastName).HasColumnName("lastname")
                .HasColumnType("nvarchar(32)");
            ent.Property(x => x.ContactTitle).HasColumnName("contacttitle")
                .HasColumnType("nvarchar(32)");
            ent.Property(x => x.Occupation).HasColumnName("occupation")
                .HasColumnType("nvarchar(32)");
            ent.Property(x => x.Phone).HasColumnName("phone")
                .HasColumnType("nvarchar(20)");
            ent.Property(x => x.Fax).HasColumnName("fax")
                .HasColumnType("nvarchar(20)");
            ent.Property(x => x.Mobile).HasColumnName("mobile")
                .HasColumnType("nvarchar(20)");
            ent.Property(x => x.Email).HasColumnName("email")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.Gender).HasColumnName("gender")
                .HasColumnType("char")
                .HasDefaultValue('M');
            ent.Property(x => x.ParentId).HasColumnName("parent_id");
            ent.Property(x => x.TypeOfContact).HasColumnName("typeofcontact")
                .HasColumnType("nvarchar(20)");

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
