

// namespace agenda_api;
// public class JwtBearerEvents : JwtBearerEventsBase
// {
//     public override async Task OnChallengeAsync(Microsoft.AspNetCore.Authentication.ChallengeContext context)
//     {
//         // Get the error message from the context.
//         string errorMessage = context.Error.Message;

//         // Customize the error message.
//         errorMessage = "The token you provided is invalid or has expired. Please generate a new token and try again.";

//         // Set the error message on the context.
//         context.Error.Message = errorMessage;

//         // Continue processing the request.
//         await base.OnChallengeAsync(context);
//     }
// }