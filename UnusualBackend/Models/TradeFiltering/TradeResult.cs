using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnusualBackend.Models.TradeFiltering;

public class TradeResult
{
    [Column("id")]
	public long Id { get; set; }
	[Column("create_moment")]
	public DateTime CreateMoment { get; set; }
	[Column("update_moment")]
	public DateTime UpdateMoment { get; set; }
	[Column("trade_date")]
	public DateTime TradeDate { get; set; }
	[Column("asset_code")]
	[MaxLength(32)]
	public string AssetCode { get; set; } = string.Empty;
	[Column("asset_name")]
	[MaxLength(256)]
	public string AssetName { get; set; } = string.Empty;
	[Column("asset_isin")]
	[MaxLength(32)]
	public string AssetIsin { get; set; } = string.Empty;
	[Column("asset_regnum")]
	[MaxLength(32)]
	public string AssetRegnum { get; set; } = string.Empty;
	[Column("asset_category")]
	[MaxLength(128)]
	public string AssetCategory { get; set; } = string.Empty;
	[Column("asset_facevalue")]
	public double AssetFacevalue { get; set; }
	[Column("asset_facevalue_currency")]
	[MaxLength(3)]
	public string AssetFacevalueCurrency { get; set; } = string.Empty;
	[Column("asset_issuer")]
	[MaxLength(255)]
	public string AssetIssuer { get; set; } = string.Empty;
	[Column("asset_lstg")]
	[MaxLength(64)]
	public string AssetLstg { get; set; } = string.Empty;
	[Column("currency")]
	[MaxLength(3)]
	public string Currency { get; set; } = string.Empty;
	[Column("is_address")]
	public bool IsAddress { get; set; }
	[Column("main_firstdeal_qty")]
	public double MainFirstdealQty { get; set; }
	[Column("main_firstdeal_volume")]
	public double MainFirstdealVolume { get; set; }
	[Column("main_lastdeal_qty")]
	public double MainLastdealQty { get; set; }
	[Column("main_lastdeal_volume")]
	public double MainLastdealVolume { get; set; }
	[Column("main_total_volume")]
	public double MainTotalVolume { get; set; }
	[Column("main_total_qty")]
	public double MainTotalQty { get; set; }
	[Column("main_deal_count")]
	public double MainDealCount { get; set; }
	[Column("main_repo_qty")]
	public double MainRepoQty { get; set; }
	[Column("main_repo_volume")]
	public double MainRepoVolume { get; set; }
	[Column("main_repo_count")]
	public double MainRepoCount { get; set; }
	[Column("main_current_price")]
	public double MainCurrentPrice { get; set; }
	[Column("main_max_deal_price")]
	public double MainMaxDealPrice { get; set; }
	[Column("main_min_deal_price")]
	public double MainMinDealPrice { get; set; }
	[Column("eve_firstdeal_qty")]
	public double EveFirstdealQty { get; set; }
	[Column("eve_firstdeal_volume")]
	public double EveFirstdealVolume { get; set; }
	[Column("eve_lastdeal_qty")]
	public double EveLastdealQty { get; set; }
	[Column("eve_lastdeal_volume")]
	public double EveLastdealVolume { get; set; }
	[Column("eve_total_volume")]
	public double EveTotalVolume { get; set; }
	[Column("eve_total_qty")]
	public double EveTotalQty { get; set; }
	[Column("eve_deal_count")]
	public double EveDealCount { get; set; }
	[Column("eve_current_price")]
	public double EveCurrentPrice { get; set; }
	[Column("eve_repo_qty")]
	public double EveRepoQty { get; set; }
	[Column("eve_repo_volume")]
	public double EveRepoVolume { get; set; }
	[Column("eve_max_deal_price")]
	public double EveMaxDealPrice { get; set; }
	[Column("eve_min_deal_price")]
	public double EveMinDealPrice { get; set; }
	[Column("total_volume")]
	public double TotalVolume { get; set; }
	[Column("total_qty")]
	public double TotalQty { get; set; }
	[Column("max_deal_price")]
	public double MaxDealPrice { get; set; }
	[Column("min_deal_price")]
	public double MinDealPrice { get; set; }
	[Column("close_price")]
	public double ClosePrice { get; set; }
	[Column("close_price_volume")]
	public double ClosePriceVolume { get; set; }
	[Column("prev_close")]
	public double PrevClose { get; set; }
	[Column("close_price_deviation")]
	public double ClosePriceDeviation { get; set; }
	[Column("wa_price")]
	public double WaPrice { get; set; }
	[Column("current_price")]
	public double CurrentPrice { get; set; }
	[Column("official_price")]
	public double OfficialPrice { get; set; }
	[Column("official_price_volume")]
	public double OfficialPriceVolume { get; set; }
	[Column("market_price_2")]
	public double MarketPrice2 { get; set; }
	[Column("market_price_2_volume")]
	public double MarketPrice2Volume { get; set; }
	[Column("market_price_3")]
	public double MarketPrice3 { get; set; }
	[Column("market_price_3_volume")]
	public double MarketPrice3Volume { get; set; }
	[Column("capitalization")]
	public double Capitalization { get; set; }
	[Column("eve_repo_count")]
	public double EveRepoCount { get; set; }
	[Column("main_firstdeal_price")]
	public double MainFirstdealPrice { get; set; }
	[Column("main_lastdeal_price")]
	public double MainLastdealPrice { get; set; }
	[Column("eve_firstdeal_price")]
	public double EveFirstdealPrice { get; set; }
	[Column("eve_lastdeal_price")]
	public double EveLastdealPrice { get; set; }
	[Column("asset_issuer_details")]
	public double AssetIssuerDetails { get; set; }
	[Column("clearing_price_prev")]
	public double ClearingPricePrev { get; set; }
	[Column("sett_type")]
	public int SettType { get; set; }
	[Column("trade_mode")]
	public string TradeMode { get; set; } = string.Empty;
	[Column("nyse_close_price")]
	public int NyseClosePrice { get; set; }
	[Column("precision")]
	public int Precision { get; set; }
	[Column("main_wa_price")]
	public int MainWaPrice { get; set; }
	[Column("eve_wa_price")]
	public int EveWaPrice { get; set; }
	[Column("first_current_price")]
	public int FirstCurrentPrice { get; set; }
	[Column("prev_current_price")]
	public int PrevCurrentPrice { get; set; }
	[Column("current_price_deviation")]
	public int CurrentPriceDeviation { get; set; }

	[Column("section_code")] 
	public string SectionCode { get; set; } = string.Empty;
	[Column("section_name")]
	public int SectionName { get; set; }
	[Column("settlement_currency")]
	public int SettlementCurrency { get; set; }
	[Column("accrued_interest")]
	public int AccruedInterest { get; set; }
	[Column("is_otc")]
	public int IsOtc { get; set; }
	[Column("clearing_price")]
	public int ClearingPrice { get; set; }
	[Column("morn_firstdeal_qty")]
	public int MornFirstdealQty { get; set; }
	[Column("morn_firstdeal_volume")]
	public int MornFirstdealVolume { get; set; }
	[Column("morn_firstdeal_price")]
	public int MornFirstdealPrice { get; set; }
	[Column("morn_lastdeal_qty")]
	public int MornLastdealQty { get; set; }
	[Column("morn_lastdeal_volume")]
	public int MornLastdealVolume { get; set; }
	[Column("morn_lastdeal_price")]
	public int MornLastdealPrice { get; set; }
	[Column("morn_max_deal_price")]
	public int MornMaxDealPrice { get; set; }
	[Column("morn_min_deal_price")]
	public int MornMinDealPrice { get; set; }
	[Column("morn_total_volume")]
	public int MornTotalVolume { get; set; }
	[Column("morn_total_qty")]
	public int MornTotalQty { get; set; }
	[Column("morn_deal_count")]
	public int MornDealCount { get; set; }
	[Column("morn_current_price")]
	public int MornCurrentPrice { get; set; }
	[Column("morn_wa_price")]
	public int MornWaPrice { get; set; }
	[Column("total_deal_count")]
	public int TotalDealCount { get; set; }
	[Column("balance_instrument_id")]
	public int BalanceInstrumentId { get; set; }
	[Column("trade_instrument_id")]
	public int TradeInstrumentId { get; set; }
	[Column("ext_security_id")]
	public int ExtSecurityId { get; set; }
	[Column("asset_category_fullname")]
	public int AssetCategoryFullname { get; set; }
	[Column("base_limit")]
	public int BaseLimit { get; set; }
	[Column("clearing_price_deviation")]
	public int ClearingPriceDeviation { get; set; }
	[Column("average_daily_volume")]
	public int AverageDailyVolume { get; set; }
	[Column("main_average_daily_volume")]
	public int MainAverageDailyVolume { get; set; }
	[Column("eve_average_daily_volume")]
	public int EveAverageDailyVolume { get; set; }
	[Column("morn_average_daily_volume")]
	public int MornAverageDailyVolume { get; set; }
	[Column("prev_split_coeff")]
	public int PrevSplitCoeff { get; set; }
}