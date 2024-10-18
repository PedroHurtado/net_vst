using System;
using System.Threading;
using System.Threading.Tasks;

class Program1
{
    static async Task Main(string[] args)
    {
        // Crear el CancellationTokenSource
        CancellationTokenSource cts = new CancellationTokenSource();

        try
        {
            // Iniciar la tarea y pasar el token
            Task task = DoWorkAsync(cts.Token);

            // Simulamos cancelar después de 2 segundos
            await Task.Delay(2000);
            cts.Cancel();

            // Esperar a que la tarea termine
            await task;
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("La operación fue cancelada.");
        }
        finally
        {
            cts.Dispose();
        }
    }

    // Método que realiza un trabajo asíncrono y admite la cancelación
    static async Task DoWorkAsync(CancellationToken cancellationToken)
    {
        for (int i = 0; i < 10; i++)
        {
            // Verificamos si se ha solicitado la cancelación
            cancellationToken.ThrowIfCancellationRequested();

            Console.WriteLine($"Trabajo en progreso... Iteración {i + 1}");

            // Simulamos trabajo asíncrono
            await Task.Delay(1000);
        }

        Console.WriteLine("Trabajo completado.");
    }
}
