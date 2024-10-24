using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wbx.Sample.Persistence.Entities;

/// <summary>
/// Контакт телефонной книги.
/// </summary>
[Table("Samples")]
public class Sample
{
    public Guid Id { get; set; }

    /// <summary>
    /// Название контакта.
    /// </summary>
    [Comment("Название.")]
    public string Name { get; set; }
}
