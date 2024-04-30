declare @response nvarchar(max);
declare @payload nvarchar(1000) = json_object('FirstName':'John', 'LastName':'Doe')

exec sp_invoke_external_rest_endpoint
    @url = 'https://dm-devday2024.azurewebsites.net/api/TriggerHTTP',
    @method = 'POST',
    @headers = '{"Content-Type":"application/json"}',
    @payload = @payload,
    @response = @response output

select @response;

select json_value(@response, '$.result.message')