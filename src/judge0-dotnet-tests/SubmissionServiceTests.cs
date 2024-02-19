using Judge0.DotNet;
using Judge0.DotNet.Exceptions;
using Judge0.DotNet.Models.Submissions;
using Microsoft.Extensions.DependencyInjection;

namespace judge0sdk_library_tests;

public class SubmissionServiceTests
{
    private IServiceProvider serviceProvider = null!;
    
    [SetUp]
    public void Setup()
    {
        serviceProvider = ServiceCollectionExtensions.GetServiceProvider();
    }

    #region CreateAsync

    [Test]
    public async Task Should_Return_SubmissionResponse_WithToken_When_CreateAsync_Is_Called() 
    {
        var submissionService = serviceProvider.GetRequiredService<ISubmissionService>();
        var submission = new Submission(
            "#include <stdio.h>\n\nint main(void) {\n  char name[10];\n  scanf(\"%s\", name);\n  printf(\"hello, %s\n\", name);\n  return 0;\n}",
            50)
        {
            Stdin = "world"
        };
        var result = await submissionService.CreateAsync(submission);

        Assert.IsNotNull(result);
        Assert.IsNotEmpty(result.Token);
    }

    [Test]
    public async Task Should_Throw_Validation_Exception_When_CreateAsync_With_Invalid_LanguageId_Is_Callend()
    {
        var submissionService = serviceProvider.GetRequiredService<ISubmissionService>();
        var submission = new Submission(
            "#include <stdio.h>\n\nint main(void) {\n  char name[10];\n  scanf(\"%s\", name);\n  printf(\"hello, %s\n\", name);\n  return 0;\n}",
            4)
        {
            Stdin = "world"
        };
        
        
        var exception = Assert.ThrowsAsync<ValidationException>(() => submissionService.CreateAsync(submission));
        Assert.IsNotNull(exception);
        Assert.IsNotNull(exception?.Errors);
        Assert.IsTrue(exception?.Errors?.ContainsKey("language_id"));
    }
    
    [Test]
    public async Task Should_Throw_Validation_Exception_When_CreateAsync_With_Invalid_WallTimeLimit_Is_Callend()
    {
        var submissionService = serviceProvider.GetRequiredService<ISubmissionService>();
        var submission = new Submission(
            "#include <stdio.h>\n\nint main(void) {\n  char name[10];\n  scanf(\"%s\", name);\n  printf(\"hello, %s\n\", name);\n  return 0;\n}",
            50)
        {
            NumberOfRuns = 1,
            Stdin = "Judge0",
            ExpectedOutput = "hello, Judge0",
            CpuTimeLimit = 1,
            CpuExtraTime = 0.5f,
            WallTimeLimit = 100000,
            MemoryLimit = 128000,
            StackLimit = 128000,
            EnablePerProcessAndThreadMemoryLimit = false,
            EnablePerProcessAndThreadTimeLimit = false,
            MaxFileSize = 1024
        };
        
        
        var exception = Assert.ThrowsAsync<ValidationException>(() => submissionService.CreateAsync(submission));
        Assert.IsNotNull(exception);
        Assert.IsNotNull(exception?.Errors);
        Assert.IsTrue(exception?.Errors?.ContainsKey("wall_time_limit"));
    }
    
    [Test]
    public async Task Should_Return_SubmissionResponse_When_CreateAsync_With_Base64_Encoded_True_Is_Callend()
    {
        var submissionService = serviceProvider.GetRequiredService<ISubmissionService>();
        var submission = new Submission(
            "I2luY2x1ZGUgPHN0ZGlvLmg+CgppbnQgbWFpbih2b2lkKSB7CiAgY2hhciBuYW1lWzEwXTsKICBzY2FuZigiJXMiLCBuYW1lKTsKICBwcmludGYoImhlbGxvLCAlc1xuIiwgbmFtZSk7CiAgcmV0dXJuIDA7Cn0=",
            50)
        {
            Stdin = "SnVkZ2Uw"
        };


        var result = await submissionService.CreateAsync(submission, true);
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.Token);
    }
    
    [Test]
    public async Task Should_Return_SubmissionResponse_When_CreateAsync_With_Wait_True_Is_Called()
    {
        var submissionService = serviceProvider.GetRequiredService<ISubmissionService>();
        var submission = new Submission(
            "#include <stdio.h>\n\nint main(void) {\n  char name[10];\n  scanf(\"%s\", name);\n  printf(\"hello, %s\\n\", name);\n  return 0;\n}",
            50)
        {
            Stdin = "Judge",
            ExpectedOutput = "hello, Judge"
        };


        var result = await submissionService.CreateAsync(submission, false, true);
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.Token);
        Assert.IsTrue(result.Stdout == "hello, Judge\n");
        Assert.IsNotNull(result.Time);
        Assert.IsNotNull(result.Memory);
        Assert.IsNull(result.Stderr);
        Assert.IsNull(result.CompileOutput);
        Assert.IsNotNull(result.Status);
        Assert.IsTrue(result.Status.Id == 3);
        Assert.IsTrue(result.Status.Description =="Accepted");
    }

    #endregion
    #region GetSubmission

    [Test]
    public async Task Should_Return_SubmissionResponse_When_CreateAsync_After_Is_Created_Is_Called()
    {
        var submissionService = serviceProvider.GetRequiredService<ISubmissionService>();
        var submission = new Submission(
            "#include <stdio.h>\n\nint main(void) {\n  char name[10];\n  scanf(\"%s\", name);\n  printf(\"hello, %s\\n\", name);\n  return 0;\n}",
            50)
        {
            Stdin = "Judge"
        };
        
        var result = await submissionService.CreateAsync(submission);
        
        System.Threading.Thread.Sleep(5000);
        var submissionResponse = await submissionService.GetAsync(result.Token, false);
        
        Assert.IsNotNull(submissionResponse);
        Assert.IsTrue(submissionResponse.Stdout == "hello, Judge\n");
    }
    
    [Test]
    public async Task Should_Return_SubmissionResponse_WithField_When_CreateAsync_After_Is_Created_Is_Called()
    {
        var submissionService = serviceProvider.GetRequiredService<ISubmissionService>();
        var submission = new Submission(
            "#include <stdio.h>\n\nint main(void) {\n  char name[10];\n  scanf(\"%s\", name);\n  printf(\"hello, %s\\n\", name);\n  return 0;\n}",
            50)
        {
            Stdin = "Judge"
        };
        
        var result = await submissionService.CreateAsync(submission);
        
        System.Threading.Thread.Sleep(5000);
        var submissionResponse = await submissionService.GetAsync(result.Token, fields: "stdout,stderr,status_id,language_id");
        
        Assert.IsNotNull(submissionResponse);
        Assert.IsNotNull(submissionResponse.LanguageId);
        Assert.IsNotNull(submissionResponse.StatusId);
        Assert.IsTrue(submissionResponse.Stdout == "hello, Judge\n");
    }
    
    [Test]
    public async Task Should_Return_SubmissionResponse_WithField_And_Base64_True_When_CreateAsync_After_Is_Created_Is_Called()
    {
        var submissionService = serviceProvider.GetRequiredService<ISubmissionService>();
        var submission = new Submission(
            "#include <stdio.h>\n\nint main(void) {\n  char name[10];\n  scanf(\"%s\", name);\n  printf(\"hello, %s\\n\", name);\n  return 0;\n}",
            50)
        {
            Stdin = "Judge"
        };
        
        var result = await submissionService.CreateAsync(submission, true);
        
        System.Threading.Thread.Sleep(5000);
        var submissionResponse = await submissionService.GetAsync(result.Token, fields: "stdout,stderr,status_id,language_id", base64Encoded:true);
        
        Assert.IsNotNull(submissionResponse);
        Assert.IsNotNull(submissionResponse.LanguageId);
        Assert.IsNotNull(submissionResponse.StatusId);
        Assert.IsTrue(submissionResponse.Stdout == "hello, Judge\n");
    }
    
    [Test]
    public async Task Should_Throw_NotFoundException_When_GetAsync_Is_Called()
    {
        var submissionService = serviceProvider.GetRequiredService<ISubmissionService>();
        
        Assert.ThrowsAsync<NotFoundException>(() => submissionService.GetAsync(Guid.NewGuid().ToString()));
        
    }
    

    #endregion
    #region GetSubissions

    [Test]
    public async Task Should_Return_ListOfSubmissionResponse_When_GetAsync_After_Is_Created_Is_Called()
    {
        var submissionService = serviceProvider.GetRequiredService<ISubmissionService>();
        var submission = new Submission(
            "#include <stdio.h>\n\nint main(void) {\n  char name[10];\n  scanf(\"%s\", name);\n  printf(\"hello, %s\\n\", name);\n  return 0;\n}",
            50)
        {
            Stdin = "Judge"
        };
        
        var result = await submissionService.CreateAsync(submission);
        
        var submissionResponse = await submissionService.GetAsync(false, 1, 1);
        
        Assert.IsNotNull(submissionResponse);
        Assert.IsTrue(submissionResponse.Submissions.Any());
    }
    
    [Test]
    public async Task Should_Return_ListOfSubmissionResponse_When_GetAsync_After_Is_Created_With_Base64Encoding_True_Is_Called()
    {
        var submissionService = serviceProvider.GetRequiredService<ISubmissionService>();
        var submission = new Submission(
            "#include <stdio.h>\n\nint main(void) {\n  char name[10];\n  scanf(\"%s\", name);\n  printf(\"hello, %s\\n\", name);\n  return 0;\n}",
            50)
        {
            Stdin = "Judge"
        };
        
        var result = await submissionService.CreateAsync(submission, true);
        
        var submissionResponse = await submissionService.GetAsync(true, 1, 1);
        
        Assert.IsNotNull(submissionResponse);
        Assert.IsTrue(submissionResponse.Submissions.Any());
    }
    
    [Test]
    public async Task Should_Throw_ErrorException_When_GetAsync_After_Is_Created_With_Page_Invalid_Is_Called()
    {
        var submissionService = serviceProvider.GetRequiredService<ISubmissionService>();
        var submission = new Submission(
            "#include <stdio.h>\n\nint main(void) {\n  char name[10];\n  scanf(\"%s\", name);\n  printf(\"hello, %s\\n\", name);\n  return 0;\n}",
            50)
        {
            Stdin = "Judge"
        };
        
        var result = await submissionService.CreateAsync(submission, true);
        
        var exception = Assert.ThrowsAsync<ErrorException>(() => submissionService.GetAsync(false, -1, 1));
        
        Assert.IsNotNull(exception);
    }
    
    [Test]
    public async Task Should_Throw_ErrorException_When_GetAsync_After_Is_Created_With_PerPage_Invalid_Is_Called()
    {
        var submissionService = serviceProvider.GetRequiredService<ISubmissionService>();
        var submission = new Submission(
            "#include <stdio.h>\n\nint main(void) {\n  char name[10];\n  scanf(\"%s\", name);\n  printf(\"hello, %s\\n\", name);\n  return 0;\n}",
            50)
        {
            Stdin = "Judge"
        };
        
        var result = await submissionService.CreateAsync(submission, true);
        
        var exception = Assert.ThrowsAsync<ErrorException>(() => submissionService.GetAsync(false, 1, -1));
        
        Assert.IsNotNull(exception);
    }
    
    [Test]
    public async Task Should_Throw_ForbiddenException_When_CreateAsync_Is_Called()
    {
        var submissionService = ServiceCollectionExtensions.GetForbiddenServiceProvider().GetRequiredService<ISubmissionService>();
        var submission = new Submission(
            "#include <stdio.h>\n\nint main(void) {\n  char name[10];\n  scanf(\"%s\", name);\n  printf(\"hello, %s\\n\", name);\n  return 0;\n}",
            50)
        {
            Stdin = "Judge"
        };
        
        var result = await submissionService.CreateAsync(submission, true);
        
        var exception = Assert.ThrowsAsync<ForbiddenException>(() => submissionService.GetAsync(false, 1, 1));
        
        Assert.IsNotNull(exception);
    }
    
    [Test]
    public async Task Should_Throw_UnauthorizedException_When_CreateAsync_Is_Called()
    {
        var submissionService = ServiceCollectionExtensions.GetUnauthorizedServiceProvider().GetRequiredService<ISubmissionService>();
        
        var exception = Assert.ThrowsAsync<UnauthorizedException>(() => submissionService.GetAsync(false, 1, 1));
        
        Assert.IsNotNull(exception);
    }
    
    #endregion
    
    #region DeleteAsync 
    [Test]
    public async Task Should_Return_SubmissionResponse_When_DeleteAsync_After_Is_Created_Is_Called()
    {
        var submissionService = serviceProvider.GetRequiredService<ISubmissionService>();
        var submission = new Submission(
            "#include <stdio.h>\n\nint main(void) {\n  char name[10];\n  scanf(\"%s\", name);\n  printf(\"hello, %s\\n\", name);\n  return 0;\n}",
            50)
        {
            Stdin = "Judge"
        };
        
        var result = await submissionService.CreateAsync(submission);
        Thread.Sleep(5000);
        var submissionResponse = await submissionService.DeleteAysnc(result.Token);
        
        Assert.IsNotNull(submissionResponse);
    }
    
    [Test]
    public async Task Should_Throw_ErrorException_When_DeleteAsync_After_Is_Created_Is_Called()
    {
        var submissionService = serviceProvider.GetRequiredService<ISubmissionService>();
        var submission = new Submission(
            "#include <stdio.h>\n\nint main(void) {\n  char name[10];\n  scanf(\"%s\", name);\n  printf(\"hello, %s\\n\", name);\n  return 0;\n}",
            50)
        {
            Stdin = "Judge"
        };
        
        var result = await submissionService.CreateAsync(submission);
        
        var exception = Assert.ThrowsAsync<ErrorException>(() => submissionService.DeleteAysnc(result.Token));
        
        Assert.IsNotNull(exception);
    }
    
    [Test]
    public async Task Should_Throw_ForbiddenException_When_DeleteAsync_Is_Called()
    {
        var submissionService = ServiceCollectionExtensions.GetForbiddenServiceProvider().GetRequiredService<ISubmissionService>();
        var submission = new Submission(
            "#include <stdio.h>\n\nint main(void) {\n  char name[10];\n  scanf(\"%s\", name);\n  printf(\"hello, %s\\n\", name);\n  return 0;\n}",
            50)
        {
            Stdin = "Judge"
        };
        
        var exception = Assert.ThrowsAsync<ForbiddenException>(() => submissionService.DeleteAysnc(Guid.NewGuid().ToString()));
        
        Assert.IsNotNull(exception);
    }
    
    [Test]
    public async Task Should_Throw_UnauthorizedException_When_DeleteAsync_Is_Called()
    {
        var submissionService = ServiceCollectionExtensions.GetUnauthorizedServiceProvider().GetRequiredService<ISubmissionService>();
        var submission = new Submission(
            "#include <stdio.h>\n\nint main(void) {\n  char name[10];\n  scanf(\"%s\", name);\n  printf(\"hello, %s\\n\", name);\n  return 0;\n}",
            50)
        {
            Stdin = "Judge"
        };
        
        var exception = Assert.ThrowsAsync<UnauthorizedException>(() => submissionService.DeleteAysnc(Guid.NewGuid().ToString()));
        
        Assert.IsNotNull(exception);
    }
    
    #endregion


    #region CreateBatch
    [Test]
    public async Task Should_Return_ListofSubmissionResponse_WithToken_When_CreateBatchAsync_Is_Called() 
    {
        var submissionService = serviceProvider.GetRequiredService<ISubmissionService>();
        SubmissionBatch submissionBatch = new()
        {
            Submissions =
            [
                new("echo hello from Bash", 46),
                new("print(\"hello from Python\")", 71),
                new("puts(\"hello from Ruby\")", 72)
            ]
        };

        var result = await submissionService.CreateBatchAsync(submissionBatch);

        Assert.IsNotNull(result);
        Assert.IsTrue(result.Any());
        Assert.IsTrue(result.Count() == 3);
    }
    
    #endregion
    
    #region GetBatch
    [Test]
    public async Task Should_Return_SubmissionsResponse_WithToken_When_GetBatchAsync_Is_Called() 
    {
        var submissionService = serviceProvider.GetRequiredService<ISubmissionService>();
        SubmissionBatch submissionBatch = new()
        {
            Submissions =
            [
                new("echo hello from Bash", 46),
                new("print(\"hello from Python\")", 71),
                new("puts(\"hello from Ruby\")", 72)
            ]
        };

        var result = await submissionService.CreateBatchAsync(submissionBatch);

        Thread.Sleep(5000);
        
        var tokens = result.Select(x => x.Token).ToArray();
        var response = await submissionService.GetBatchAsync(tokens, true);
        
        
        Assert.IsNotNull(response);
        Assert.IsTrue(response.Submissions.Any());
    }
    #endregion
}