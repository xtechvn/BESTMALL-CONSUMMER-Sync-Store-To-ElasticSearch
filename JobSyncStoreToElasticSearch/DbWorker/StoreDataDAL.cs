using JobSyncStoreToElasticSearch.Constant;
using JobSyncStoreToElasticSearch.DbWorker.Biolife;
using JobSyncStoreToElasticSearch.DbWorker.Hulotoys;
using JobSyncStoreToElasticSearch.Models;
using Newtonsoft.Json;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace JobSyncStoreToElasticSearch.DbWorker
{
    public class StoreDataDAL
    {
        public static DataConfigResultModel getDataFromStore(DataInfoModel obj_data)
        {
            try
            {
                string connection_source = string.Empty;
                string json_data_source = string.Empty;
                string node_es_target = string.Empty;
                string es_host_target = string.Empty; // dia chi es
                switch (obj_data.project_type)
                {
                    
                    case ProjectType.HULOTOYS:
                        connection_source = ConfigurationManager.AppSettings["database_hulotoys"].ToString(); // Chuỗi connect tới Database                             
                        es_host_target = ConfigurationManager.AppSettings["es_master"].ToString();  // dia chi es để tranfer data

                        // Connect lấy data
                        var data_hulotoys = new HulotoysRepository(connection_source, obj_data.store_name);
                        switch (obj_data.store_name)
                        {
                            case "SP_GetAllArticle":
                                json_data_source = data_hulotoys.GetDataById(Convert.ToInt32(obj_data.id));
                                break;

                            case "SP_GetGroupProduct":
                                json_data_source = data_hulotoys.GetDataById(Convert.ToInt32(obj_data.id));
                                break;
                            case "SP_GetAccountClient":
                                json_data_source = data_hulotoys.GetDataById(Convert.ToInt32(obj_data.id));
                                break;
                            case "sp_GetClient":
                                json_data_source = data_hulotoys.GetDataById(Convert.ToInt32(obj_data.id));
                                break;
                            case "SP_GetOrder":
                                json_data_source = data_hulotoys.GetDataById(Convert.ToInt32(obj_data.id));
                                break;
                            case "SP_GetAccountAccessApi":
                                json_data_source = data_hulotoys.GetDataById(Convert.ToInt32(obj_data.id));
                                break;
                            case "SP_GetArticle":
                                json_data_source = data_hulotoys.GetDataById(Convert.ToInt32(obj_data.id));
                                break;
                            case "SP_GetArticleCategory":
                                json_data_source = data_hulotoys.GetDataById(Convert.ToInt32(obj_data.id));
                                break;
                            case "SP_GetArticleRelated":
                                json_data_source = data_hulotoys.GetDataById(Convert.ToInt32(obj_data.id));
                                break;
                            case "SP_GetTag":
                                json_data_source = data_hulotoys.GetDataById(Convert.ToInt32(obj_data.id));
                                break;
                            case "SP_GetLocationProduct":
                                json_data_source = data_hulotoys.GetDataById(Convert.ToInt32(obj_data.id));
                                break;
                            case "SP_GetUser":
                                json_data_source = data_hulotoys.GetDataById(Convert.ToInt32(obj_data.id));
                                break;
                            case "SP_GetAddressClient":
                                json_data_source = data_hulotoys.GetDataById(Convert.ToInt32(obj_data.id));
                                break;
                            case "SP_GetProvince":
                                json_data_source = data_hulotoys.GetDataById(Convert.ToInt32(obj_data.id));
                                break;
                            case "SP_GetDistrict":
                                json_data_source = data_hulotoys.GetDataById(Convert.ToInt32(obj_data.id));
                                break;
                            case "SP_GetWard":
                                json_data_source = data_hulotoys.GetDataById(Convert.ToInt32(obj_data.id));
                                break;
                            case "SP_GetOrderDetail":
                                json_data_source = data_hulotoys.GetDataById(Convert.ToInt32(obj_data.id));
                                break;
                            case "SP_GetRating":
                                json_data_source = data_hulotoys.GetDataById(Convert.ToInt32(obj_data.id));
                                break;
                            case "SP_GetAccountAccessAPIPermission":
                                json_data_source = data_hulotoys.GetDataById(Convert.ToInt32(obj_data.id));
                                break;
                            case "sp_getOrderDetail":
                                json_data_source = data_hulotoys.GetDataById(Convert.ToInt32(obj_data.id));
                                break;
                            case "SP_GetArticleTagData":
                                json_data_source = data_hulotoys.GetDataById(Convert.ToInt32(obj_data.id));
                                break;
                            case "SP_GetOrderMerge":
                                json_data_source = data_hulotoys.GetDataById(Convert.ToInt32(obj_data.id));
                                break;

                            default:
                                break;
                        }

                        break;
                   
                    default:
                        break;
                }

                var model = new DataConfigResultModel
                {
                    data_source = json_data_source,
                    index_node = obj_data.index_es,
                    es_host_target = es_host_target
                };
                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
