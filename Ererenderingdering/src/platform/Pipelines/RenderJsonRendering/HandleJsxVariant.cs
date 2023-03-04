using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.LayoutService.Configuration;
using Sitecore.LayoutService.Presentation.Pipelines.RenderJsonRendering;
using Sitecore.Mvc.Presentation;

namespace Ererenderingdering.Pipelines.RenderJsonRendering
{
    public class HandleJsxVariant : BaseRenderJsonRendering
    {
        private const string FirldNamesParameterName = "FieldNames";

        private readonly ID JsxFieldId = new ID("{8D4AA8A0-68B4-4EC4-B88C-08BEEC780414}");

        private readonly ISitecoreContext _context;
        
        public HandleJsxVariant(IConfiguration configuration, ISitecoreContext context)
            : base(configuration)
        {
            Assert.ArgumentNotNull(context, nameof(context));

            _context = context;
        }

        protected override void SetResult(RenderJsonRenderingArgs args)
        {
            IDictionary<string, string> renderingParameters = args.Result.RenderingParams;
            if (!renderingParameters.Any())
            {
                return;
            }

            if (!renderingParameters.ContainsKey(FirldNamesParameterName))
            {
                return;
            }

            Item variantItem = GetVariantItem(args.Rendering);
            if (variantItem == null)
            {
                return;
            }

            Field variantJsxField = variantItem.Fields[JsxFieldId];
            if (variantJsxField == null)
            {
                return;
            }

            string variantJsx = variantJsxField.Value;
            if (string.IsNullOrEmpty(variantJsx))
            {
                return;
            }
            
            OverwriteFieldNamesParameter(renderingParameters);
            AddJsxToContent(variantJsx, args);
        }

        private void OverwriteFieldNamesParameter(IDictionary<string, string> renderingParameters)
        {
            renderingParameters[FirldNamesParameterName] = "JSX";
        }

        private void AddJsxToContent(string jsx, RenderJsonRenderingArgs args)
        {
            JObject content = args.Result.Contents as JObject;
            if (content == null)
            {
                return;
            }

            JToken jsxToken = JToken.Parse(JsonConvert.SerializeObject(jsx));
            content.Add("VariantJsx", jsxToken);
        }

        private Item GetVariantItem(Rendering rendering)
        {
            string variant = rendering.Parameters[FirldNamesParameterName];
            if (string.IsNullOrEmpty(variant))
            {
                return null;
            }

            Database contextDatabase = _context.GetContextDatabase();
            Assert.IsNotNull(contextDatabase, nameof(contextDatabase));

            if (!ID.TryParse(variant, out ID variantId))
            {
                return null;
            }

            return contextDatabase.GetItem(variantId);
        }
    }
}