﻿namespace ProniaTemplate.Exceptions;

public class ItemNotFoundException : Exception
{
    public ItemNotFoundException(string message = "Item not found!") : base(message) { }
}
