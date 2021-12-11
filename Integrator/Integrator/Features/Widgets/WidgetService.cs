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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WidgetService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public string CreateWidget(WidgetDTO widgetDto)
        {
            var widget = _mapper.Map<Widget>(widgetDto);

            _unitOfWork.Widgets.Insert(widget);
            _unitOfWork.Complete();

            return widget.Id;
        }

        public string DeleteWidget(string id)
        {
            _unitOfWork.Widgets.Delete(id);
            _unitOfWork.Complete();

            return id;
        }

        public IEnumerable<WidgetDTO> ListWidgets()
        {
            var res = _unitOfWork.Widgets.ListAll()
            .Select(widget => new WidgetDTO
            {
                Id = widget.Id,
                Title = widget.Title,
                Type = widget.Type
            });

            return res;
        }
        private readonly HttpClient client = new HttpClient();
        public async Task<Tuple<string, string, string>> CreateData(string widgetId, Dictionary<string, string> json, string publisherId)
        {
            var jsonAsUrl = new FormUrlEncodedContent(json);

            var widget = _mapper.Map<Widget>(ListWidgets().First(w => w.Id == widgetId));
            
            var response = await client.PostAsync(widget.Url, jsonAsUrl);

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
