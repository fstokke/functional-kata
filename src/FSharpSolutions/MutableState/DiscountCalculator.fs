namespace FunctionalKata.MutableState

type DiscountCalculator(
    minimumFlatDiscountAmount: decimal,
    minimumBulkDiscountQuantity: int,
    flatDiscountRate: decimal,
    bulkDiscountRate: decimal) =

    new() = DiscountCalculator(1000m, 10, 0.1m, 0.05m)

    member this.CalculateDiscount(cart: ShoppingCart) : decimal =
        let flatDiscount =
            if cart.TotalAmount >= minimumFlatDiscountAmount then
                cart.TotalAmount * flatDiscountRate
            else
                0m
        
        let bulkDiscount =
            cart.Items
            |> Seq.sumBy (fun item ->
                if item.Quantity >= minimumBulkDiscountQuantity then
                    item.Price * decimal item.Quantity * bulkDiscountRate
                else
                    0m)
        
        flatDiscount + bulkDiscount
