using Domain.Enums;

namespace Domain.Mappers
{
    public static class MangaMapper
    {
        public static MangaFormat? ToDomainFormat(MangaFormatDto? format)
        {
            return format.HasValue ? (MangaFormat)format.Value : null;
        }

        public static MangaSeason? ToDomainSeason(MangaSeasonDto? season)
        {
            return season.HasValue ? (MangaSeason)season.Value : null;
        }

        public static MangaRegion? ToDomainRegion(MangaRegionDto? region)
        {
            return region.HasValue ? (MangaRegion)region.Value : null;
        }

        public static MangaReleaseStatus? ToDomainReleaseStatus(MangaReleaseStatusDto? status)
        {
            return status.HasValue ? (MangaReleaseStatus)status.Value : null;
        }

        public static MangaFormatDto? ToDtoFormat(MangaFormat? format)
        {
            return format.HasValue ? (MangaFormatDto)format.Value : null;
        }

        public static MangaSeasonDto? ToDtoSeason(MangaSeason? season)
        {
            return season.HasValue ? (MangaSeasonDto)season.Value : null;
        }

        public static MangaRegionDto? ToDtoRegion(MangaRegion? region)
        {
            return region.HasValue ? (MangaRegionDto)region.Value : null;
        }

        public static MangaReleaseStatusDto? ToDtoReleaseStatus(MangaReleaseStatus? status)
        {
            return status.HasValue ? (MangaReleaseStatusDto)status.Value : null;
        }
    }
}