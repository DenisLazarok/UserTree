using System.Data.Common;

namespace UserTree.Domain.Entities;

public class JournalEvent
{
    public int Id { get; set; }
    public string? Type { get; set; }
    public string? Data { get; set; }
    public string? StackTrace { get; set; }
    public DateTimeOffset TimeOffset { get; set; }
    public string? RequestData { get; set; }
}