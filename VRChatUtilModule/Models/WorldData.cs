using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VRChatApiWrapper;
using VRChatApiWrapper.WorldApi;

namespace VRChatUtilModule.Models
{
    public class WorldData
    {
        /// <summary>
        /// ワールド情報を取得します。
        /// </summary>
        /// <param name="wrapper"></param>
        /// <param name="worldId"></param>
        /// <returns></returns>
        public async Task<WorldInfo> GetWorldAsync(VrchatApiWrapper wrapper, string worldId)
        {
            try
            {
                return await wrapper.World.GetByIdAsync(worldId);
            }
            catch (Exception)
            {
                // ignored
            }

            return null;
        }

        /// <summary>
        /// ワールドのインスタンス情報を取得します。
        /// </summary>
        /// <param name="wrapper"></param>
        /// <param name="worldId"></param>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        public async Task<InstanceInfo> GetInstanceAsync(VrchatApiWrapper wrapper, string worldId, string instanceId)
        {
            try
            {
                var instanceInfo = await wrapper.World.GetInstanceInfoAsync(worldId, instanceId);
                if (instanceInfo != null)
                {
                    return instanceInfo;
                }
            }
            catch (Exception)
            {
                // ignored
            }

            return null;
        }

        /// <summary>
        /// ワールドを検索します。
        /// </summary>
        /// <param name="wrapper"></param>
        /// <param name="searchOption"></param>
        /// <returns></returns>
        public async Task<List<WorldInfo>> SearchWorldAsync(VrchatApiWrapper wrapper, WorldSearchOption searchOption = null)
        {

            var worldBriefResponse = new List<WorldInfo>();
            var offset = 0;
            for (;;)
            {
                var world = new List<WorldInfo>();
                try
                {
                    if (searchOption == null || searchOption.NoOption)
                        world = await wrapper.World.SearchAsync(offset: offset);
                    else
                    {
                        world = await wrapper.World.SearchAsync(offset: offset, keyword: searchOption.Keyword,
                            endpointType: searchOption.EndpointType, sort: searchOption.SortOptions,
                            featured: searchOption.IsFeatured);

                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                    Console.Error.WriteLine(ex.StackTrace);
                }

                worldBriefResponse.AddRange(world);

                if (world.Count < 20)
                {
                    break;
                }

                offset += worldBriefResponse.Count;

            }

            return worldBriefResponse;
        }
    }
}
