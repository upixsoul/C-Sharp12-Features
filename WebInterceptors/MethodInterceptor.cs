using Castle.DynamicProxy;

namespace WebInterceptors
{
    public class MethodInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine($"Before method: {invocation.Method.Name}");

            // You can add conditional logic based on method name or arguments here
            if (invocation.Method.Name == "ReadData")
            {
                Console.WriteLine($"Input: {invocation.Arguments[0]}");
            }

            invocation.Proceed(); // Call the actual method

            Console.WriteLine($"After method: {invocation.Method.Name}");
            Console.WriteLine($"Output: {invocation.ReturnValue}");
        }
    }
}
