using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Domain.Models;
using FluentValidation;

namespace App.Domain.Validators
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(x => x.CustomerId)
                .GreaterThan(0).WithMessage("Customer ID must be greater than 0.");

            RuleFor(x => x.OrderDate)
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Order date cannot be in the future.");

            RuleFor(x => x.OrderItems)
                .NotEmpty().WithMessage("At least one order item is required.");

            // Validate each OrderItem in the OrderItems list
            RuleForEach(x => x.OrderItems).SetValidator(new OrderItemValidator());

            // Example of async validation (fake async operation)
            RuleFor(x => x.CustomerId)
                .MustAsync(BeValidCustomerAsync).WithMessage("Customer does not exist.");
        }

        private async Task<bool> BeValidCustomerAsync(int customerId, CancellationToken cancellationToken)
        {
            // Simulate an async operation (e.g., checking if the customer exists in a database)
            await Task.Delay(100); // Fake delay
            return customerId == 1; // Assume customer with ID 1 exists
        }
    }
}