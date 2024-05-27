using System;
using System.Collections.Generic;

namespace test.DbEntities.Models;

public partial class Chat
{
    public int Id { get; set; }

    public string Senderid { get; set; } = null!;

    public string Receiverid { get; set; } = null!;

    public TimeOnly Senttime { get; set; }

    public DateTime Sentdate { get; set; }

    public string? Message { get; set; }

    public virtual AspNetUser Receiver { get; set; } = null!;

    public virtual AspNetUser Sender { get; set; } = null!;
}
