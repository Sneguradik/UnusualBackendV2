using System.ComponentModel.DataAnnotations.Schema;

namespace UnusualBackend.Models.TradeFiltering;

public class TradeBS
{
    [Column("deal_id")]
	public int DealId { get; set; }
	[Column("trade_moment")]
	public int TradeMoment { get; set; }
	[Column("deal_date")]
	public int DealDate { get; set; }
	[Column("deal_time")]
	public int DealTime { get; set; }
	[Column("session_id")]
	public int SessionId { get; set; }
	[Column("session_time_finish")]
	public int SessionTimeFinish { get; set; }
	[Column("trade_date")]
	public DateTime TradeDate { get; set; }
	[Column("trade_period")]
	public int TradePeriod { get; set; }
	[Column("is_address")]
	public int IsAddress { get; set; }
	[Column("otc_init")]
	public int OtcInit { get; set; }
	[Column("otc_conf")]
	public int OtcConf { get; set; }
	[Column("clorder_id")]
	public int ClorderId { get; set; }
	[Column("secorder_id")]
	public int SecorderId { get; set; }
	[Column("exchorder_id")]
	public int ExchorderId { get; set; }
	[Column("order_id")]
	public int OrderId { get; set; }
	[Column("order_type")]
	public int OrderType { get; set; }
	[Column("user_id")]
	public int UserId { get; set; }
	[Column("order_comment")]
	public int OrderComment { get; set; }
	[Column("order_signs")]
	public int OrderSigns { get; set; }
	[Column("trade_member_id")]
	public int TradeMemberId { get; set; }
	[Column("trade_member_code")]
	public int TradeMemberCode { get; set; }
	[Column("trade_member_name")]
	public int TradeMemberName { get; set; }
	[Column("trade_member_details")]
	public int TradeMemberDetails { get; set; }
	[Column("contra_member_code")]
	public int ContraMemberCode { get; set; }
	[Column("contra_member_name")]
	public int ContraMemberName { get; set; }
	[Column("contra_member_details")]
	public int ContraMemberDetails { get; set; }
	[Column("account")]
	public int Account { get; set; }
	[Column("subaccount")]
	public int Subaccount { get; set; }
	[Column("client_id")]
	public int ClientId { get; set; }
	[Column("client_code")]
	public string ClientCode { get; set; }
	[Column("client_legal_code")]
	public int ClientLegalCode { get; set; }
	[Column("client_regulator_code")]
	public int ClientRegulatorCode { get; set; }
	[Column("contra_client_regulator_code")]
	public int ContraClientRegulatorCode { get; set; }
	[Column("contra_client_id")]
	public int ContraClientId { get; set; }
	[Column("instrument_id")]
	public int InstrumentId { get; set; }
	[Column("instrument_name")]
	public int InstrumentName { get; set; }
	[Column("instrument_shortname")]
	public int InstrumentShortname { get; set; }
	[Column("instrument_type")]
	public int InstrumentType { get; set; }
	[Column("instrument_lotsize")]
	public int InstrumentLotsize { get; set; }
	[Column("asset_id")]
	public int AssetId { get; set; }
	[Column("asset_code")]
	public int AssetCode { get; set; }
	[Column("asset_name")]
	public int AssetName { get; set; }
	[Column("asset_isin")]
	public int AssetIsin { get; set; }
	[Column("asset_lstg")]
	public int AssetLstg { get; set; }
	[Column("asset_type")]
	public int AssetType { get; set; }
	[Column("asset_category")]
	public int AssetCategory { get; set; }
	[Column("asset_regnum")]
	public int AssetRegnum { get; set; }
	[Column("asset_face_value")]
	public int AssetFaceValue { get; set; }
	[Column("asset_face_value_currency")]
	public int AssetFaceValueCurrency { get; set; }
	[Column("section_code")]
	public int SectionCode { get; set; }
	[Column("section_name")]
	public int SectionName { get; set; }
	[Column("currency")]
	public string Currency { get; set; }
	[Column("trade_qty")]
	public int TradeQty { get; set; }
	[Column("delivery_qty")]
	public int DeliveryQty { get; set; }
	[Column("price")]
	public int Price { get; set; }
	[Column("repo_rate")]
	public int RepoRate { get; set; }
	[Column("repurchase_price")]
	public int RepurchasePrice { get; set; }
	[Column("trade_value")]
	public int TradeValue { get; set; }
	[Column("repurchase_value")]
	public int RepurchaseValue { get; set; }
	[Column("due_date")]
	public int DueDate { get; set; }
	[Column("maturity_date")]
	public int MaturityDate { get; set; }
	[Column("match_id")]
	public int MatchId { get; set; }
	[Column("exec_market")]
	public int ExecMarket { get; set; }
	[Column("is_edelivery")]
	public int IsEdelivery { get; set; }
	[Column("default_type")]
	public int DefaultType { get; set; }
	[Column("clr_deal_id")]
	public int ClrDealId { get; set; }
	[Column("buyback_clr_deal_id")]
	public int BuybackClrDealId { get; set; }
	[Column("exch_fee")]
	public int ExchFee { get; set; }
	[Column("accr_interest")]
	public int AccrInterest { get; set; }
	[Column("dir")]
	public int Dir { get; set; }
	[Column("contra_order_id")]
	public int ContraOrderId { get; set; }
	[Column("contra_exchorder_id")]
	public int ContraExchorderId { get; set; }
	[Column("contra_client_code")]
	public int ContraClientCode { get; set; }
	[Column("contra_user_id")]
	public int ContraUserId { get; set; }
	[Column("is_nyseclose")]
	public int IsNyseclose { get; set; }
	[Column("trade_mode")]
	public string TradeMode { get; set; }
	[Column("is_mm")]
	public int IsMm { get; set; }
	[Column("account_id")]
	public int AccountId { get; set; }
	[Column("subaccount_id")]
	public int SubaccountId { get; set; }
	[Column("in_stat")]
	public int InStat { get; set; }
	[Column("contra_account_id")]
	public int ContraAccountId { get; set; }
	[Column("contra_subaccount_id")]
	public int ContraSubaccountId { get; set; }
	[Column("is_tech_trade")]
	public int IsTechTrade { get; set; }
	[Column("contra_is_mm")]
	public int ContraIsMm { get; set; }
	[Column("contra_order_type")]
	public int ContraOrderType { get; set; }
	[Column("sett_type")]
	public int SettType { get; set; }
	[Column("decimals")]
	public int Decimals { get; set; }
	[Column("clearing_member_id")]
	public int ClearingMemberId { get; set; }
	[Column("clearing_member_code")]
	public int ClearingMemberCode { get; set; }
	[Column("clearing_member_name")]
	public int ClearingMemberName { get; set; }
	[Column("clearing_member_details")]
	public int ClearingMemberDetails { get; set; }
	[Column("traded_balance_instr_id1")]
	public int TradedBalanceInstrId1 { get; set; }
	[Column("traded_balance_instr_name1")]
	public int TradedBalanceInstrName1 { get; set; }
	[Column("measuring_balance_instr_id1")]
	public int MeasuringBalanceInstrId1 { get; set; }
	[Column("traded_balance_instr_id2")]
	public int TradedBalanceInstrId2 { get; set; }
	[Column("traded_balance_instr_name2")]
	public int TradedBalanceInstrName2 { get; set; }
	[Column("measuring_balance_instr_id2")]
	public int MeasuringBalanceInstrId2 { get; set; }
	[Column("is_fee_clutch")]
	public int IsFeeClutch { get; set; }
	[Column("currency_name")]
	public int CurrencyName { get; set; }
	[Column("price_currency")]
	public int PriceCurrency { get; set; }
	[Column("price_currency_name")]
	public int PriceCurrencyName { get; set; }
	[Column("is_extra_liqudity")]
	public int IsExtraLiqudity { get; set; }
	[Column("manual_routing")]
	public int ManualRouting { get; set; }
	[Column("is_ipo")]
	public int IsIpo { get; set; }
	[Column("is_conversion")]
	public int IsConversion { get; set; }
	[Column("is_ccp")]
	public int IsCcp { get; set; }
	[Column("is_otc")]
	public int IsOtc { get; set; }
	[Column("clr_fee")]
	public int ClrFee { get; set; }
	[Column("contra_clr_fee")]
	public int ContraClrFee { get; set; }
	[Column("fee_currency")]
	public int FeeCurrency { get; set; }
	[Column("trade_mode_id")]
	public int TradeModeId { get; set; }
	[Column("contra_order_signs")]
	public int ContraOrderSigns { get; set; }
	[Column("contra_exch_fee")]
	public int ContraExchFee { get; set; }
	[Column("order_price")]
	public int OrderPrice { get; set; }
	[Column("contra_order_price")]
	public int ContraOrderPrice { get; set; }
	[Column("expiration_date")]
	public int ExpirationDate { get; set; }
	[Column("is_zero_strike")]
	public int IsZeroStrike { get; set; }
	[Column("asset_strike")]
	public int AssetStrike { get; set; }
	[Column("trade_mode_report_id")]
	public int TradeModeReportId { get; set; }
}