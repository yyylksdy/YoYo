﻿using System.Collections.Generic;
using Nop.Plugin.Api.DTOs.Images;

namespace Nop.Plugin.Api.Attributes
{
    public class ImageCollectionValidationAttribute : BaseValidationAttribute
    {
        private Dictionary<string, string> _errors = new Dictionary<string, string>();

        public override void Validate(object instance)
        {
            var imagesCollection = instance as ICollection<ImageDto>;

            foreach (var image in imagesCollection)
            {
                var imageValidationAttribute = new ImageValidationAttribute();

                imageValidationAttribute.Validate(image);

                Dictionary<string, string> errorsForImage = imageValidationAttribute.GetErrors();

                if (errorsForImage.Count > 0)
                {
                    _errors = errorsForImage;
                    break;
                }
            }
        }

        public override Dictionary<string, string> GetErrors()
        {
            return _errors;
        }
    }
}