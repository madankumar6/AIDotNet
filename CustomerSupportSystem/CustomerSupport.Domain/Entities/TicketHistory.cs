
namespace CustomerSupport.Domain.Entities
{
    public sealed class TicketHistory : BaseEntity<int>
    {
        public int SupportTicketId { get; set; }
        public int ChangedByUserId { get; set; }

        // Action tells us what business operation performed the change, e.g., "StatusChanged", "PriorityChanged", "CommentAdded", etc.
        public string Action { get; set; } = string.Empty;
        // FieldName tells us which field was changed, e.g., "Status", "Priority", "AssignedTo", etc.
        // FieldName = Status, OldValue = "Open", NewValue = "In Progress"
        public string? FieldName { get; set; }
        public string? OldValue { get; set; }
        public string? NewValue { get; set; }
        public string? Remarks { get; set; }
        public SupportTicket SupportTicket { get; set; } = null!;
        public User ChangedByUser { get; set; } = null!;
    }
}
