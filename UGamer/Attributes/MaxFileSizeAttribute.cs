namespace UGamer.Attributes
{
	public class MaxFileSizeAttribute:ValidationAttribute
	{

		private readonly int _maxFileSizeInBytes;

		public MaxFileSizeAttribute(int maxFileSizeInBytes)
		{
			_maxFileSizeInBytes = maxFileSizeInBytes;

		}

		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			var file = value as IFormFile;
			if (file is not null)
			{
				var fileSize = file.Length; //in bytes

				var isAllowed = fileSize< _maxFileSizeInBytes;

				if (!isAllowed)
				{
					return new ValidationResult
						($"Maximum File Size Allowed is {_maxFileSizeInBytes/(1024*1024)} MB ");
				}

			}
			return ValidationResult.Success;

		}
	}
}

