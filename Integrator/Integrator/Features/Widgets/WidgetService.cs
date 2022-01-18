using AutoMapper;
using Integrator.Features.Widgets.DTO;
using Integrator.Infrastructure;
using System;
using Integrator.Features.Widgets.Models;
using Integrator.Features.Workspaces.DTO;
using Integrator.Features.Workspaces.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Integrator.Features.Widgets
{
    public class WidgetService : IWidgetService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public WidgetService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public string CreateWidget(WidgetDto widgetDto)
        {
            var widget = mapper.Map<Widget>(widgetDto);

            unitOfWork.Widgets.Insert(widget);
            unitOfWork.Complete();

            return widget.Id;
        }

        public string DeleteWidget(string id)
        {
            unitOfWork.Widgets.Delete(id);
            unitOfWork.Complete();

            return id;
        }

        public IEnumerable<WidgetDto> ListWidgets()
        {
            var res = _unitOfWork.Widgets.ListAll()
                
            .Select(widget => new WidgetDTO
            {
                Id = widget.Id,
                Title = widget.Title,
                Type = widget.Type,
                Url = widget.Url,
                Options = widget.Options
            });

            return res;
        }
        private readonly HttpClient client = new HttpClient();
        public async Task<Tuple<string, string, string>> CreateData(string widgetId, Dictionary<string, string> json, string publisherId)
        {
            var jsonEncoded = new FormUrlEncodedContent(json);
            var widget = _mapper.Map<Widget>(ListWidgets().First(w => w.Id == widgetId));
            var response = await client.PostAsync(widget.Url, jsonEncoded);
            string guidFromTimesmart = await response.Content.ReadAsStringAsync();
            
            return new Tuple<string, string, string>(guidFromTimesmart, publisherId, widgetId);
        }

        // public async void getTracability(string orderId)
        // {
        //     // Widget[] creators = [new Widget()] // GetMappingsFromOrder(orderID);
        //     //var data = creators.Select(c => c.getAllData(orderId));
        //     // return new Tracability(data);
        // }
    }
}
