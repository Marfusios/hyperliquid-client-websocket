using Hyperliquid.Client.Websocket.Utils;

namespace Hyperliquid.Client.Websocket.Enums
{
    /// <summary>
    /// Represents the status of an order
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// Unknown or unspecified status
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Order is open and active
        /// </summary>
        [StringValue("open")]
        Open,

        /// <summary>
        /// Order placed successfully
        /// </summary>
        [StringValue("Placed successfully")]
        PlacedSuccessfully,

        /// <summary>
        /// Order has been filled
        /// </summary>
        [StringValue("filled")]
        Filled,

        /// <summary>
        /// Order filled
        /// </summary>
        [StringValue("Filled")]
        FilledCapitalized,

        /// <summary>
        /// Order canceled by user
        /// </summary>
        [StringValue("canceled")]
        Canceled,

        /// <summary>
        /// Order canceled by user
        /// </summary>
        [StringValue("Canceled by user")]
        CanceledByUser,

        /// <summary>
        /// Trigger order has been triggered
        /// </summary>
        [StringValue("triggered")]
        Triggered,

        /// <summary>
        /// Trigger order triggered
        /// </summary>
        [StringValue("Trigger order triggered")]
        TriggerOrderTriggered,

        /// <summary>
        /// Order rejected at time of placement
        /// </summary>
        [StringValue("rejected")]
        Rejected,

        /// <summary>
        /// Order rejected at time of placement
        /// </summary>
        [StringValue("Rejected at time of placement")]
        RejectedAtTimeOfPlacement,

        /// <summary>
        /// Canceled because insufficient margin to fill
        /// </summary>
        [StringValue("marginCanceled")]
        MarginCanceled,

        /// <summary>
        /// Canceled because insufficient margin to fill
        /// </summary>
        [StringValue("Canceled because insufficient margin to fill")]
        CanceledBecauseInsufficientMarginToFill,

        /// <summary>
        /// Vaults only. Canceled due to a user's withdrawal from vault
        /// </summary>
        [StringValue("vaultWithdrawalCanceled")]
        VaultWithdrawalCanceled,

        /// <summary>
        /// Vaults only. Canceled due to a user's withdrawal from vault
        /// </summary>
        [StringValue("Vaults only. Canceled due to a user's withdrawal from vault")]
        VaultsOnlyCanceledDueToUsersWithdrawalFromVault,

        /// <summary>
        /// Canceled due to order being too aggressive when open interest was at cap
        /// </summary>
        [StringValue("openInterestCapCanceled")]
        OpenInterestCapCanceled,

        /// <summary>
        /// Canceled due to order being too aggressive when open interest was at cap
        /// </summary>
        [StringValue("Canceled due to order being too aggressive when open interest was at cap")]
        CanceledDueToOrderBeingTooAggressiveWhenOpenInterestWasAtCap,

        /// <summary>
        /// Canceled due to self-trade prevention
        /// </summary>
        [StringValue("selfTradeCanceled")]
        SelfTradeCanceled,

        /// <summary>
        /// Canceled due to self-trade prevention
        /// </summary>
        [StringValue("Canceled due to self-trade prevention")]
        CanceledDueToSelfTradePrevention,

        /// <summary>
        /// Canceled reduced-only order that does not reduce position
        /// </summary>
        [StringValue("reduceOnlyCanceled")]
        ReduceOnlyCanceled,

        /// <summary>
        /// Canceled reduced-only order that does not reduce position
        /// </summary>
        [StringValue("Canceled reduced-only order that does not reduce position")]
        CanceledReducedOnlyOrderThatDoesNotReducePosition,

        /// <summary>
        /// TP/SL only. Canceled due to sibling ordering being filled
        /// </summary>
        [StringValue("siblingFilledCanceled")]
        SiblingFilledCanceled,

        /// <summary>
        /// TP/SL only. Canceled due to sibling ordering being filled
        /// </summary>
        [StringValue("TP/SL only. Canceled due to sibling ordering being filled")]
        TpSlOnlyCanceledDueToSiblingOrderingBeingFilled,

        /// <summary>
        /// Canceled due to asset delisting
        /// </summary>
        [StringValue("delistedCanceled")]
        DelistedCanceled,

        /// <summary>
        /// Canceled due to asset delisting
        /// </summary>
        [StringValue("Canceled due to asset delisting")]
        CanceledDueToAssetDelisting,

        /// <summary>
        /// Canceled due to liquidation
        /// </summary>
        [StringValue("liquidatedCanceled")]
        LiquidatedCanceled,

        /// <summary>
        /// Canceled due to liquidation
        /// </summary>
        [StringValue("Canceled due to liquidation")]
        CanceledDueToLiquidation,

        /// <summary>
        /// API only. Canceled due to exceeding scheduled cancel deadline (dead man's switch)
        /// </summary>
        [StringValue("scheduledCancel")]
        ScheduledCancel,

        /// <summary>
        /// API only. Canceled due to exceeding scheduled cancel deadline (dead man's switch)
        /// </summary>
        [StringValue("API only. Canceled due to exceeding scheduled cancel deadline (dead man's switch)")]
        ApiOnlyCanceledDueToExceedingScheduledCancelDeadline,

        /// <summary>
        /// Rejected due to invalid tick price
        /// </summary>
        [StringValue("tickRejected")]
        TickRejected,

        /// <summary>
        /// Rejected due to invalid tick price
        /// </summary>
        [StringValue("Rejected due to invalid tick price")]
        RejectedDueToInvalidTickPrice,

        /// <summary>
        /// Rejected due to order notional below minimum
        /// </summary>
        [StringValue("minTradeNtlRejected")]
        MinTradeNtlRejected,

        /// <summary>
        /// Rejected due to order notional below minimum
        /// </summary>
        [StringValue("Rejected due to order notional below minimum")]
        RejectedDueToOrderNotionalBelowMinimum,

        /// <summary>
        /// Rejected due to insufficient margin
        /// </summary>
        [StringValue("perpMarginRejected")]
        PerpMarginRejected,

        /// <summary>
        /// Rejected due to insufficient margin
        /// </summary>
        [StringValue("Rejected due to insufficient margin")]
        RejectedDueToInsufficientMargin,

        /// <summary>
        /// Rejected due to reduce only
        /// </summary>
        [StringValue("reduceOnlyRejected")]
        ReduceOnlyRejected,

        /// <summary>
        /// Rejected due to reduce only
        /// </summary>
        [StringValue("Rejected due to reduce only")]
        RejectedDueToReduceOnly,

        /// <summary>
        /// Rejected due to post-only immediate match
        /// </summary>
        [StringValue("badAloPxRejected")]
        BadAloPxRejected,

        /// <summary>
        /// Rejected due to post-only immediate match
        /// </summary>
        [StringValue("Rejected due to post-only immediate match")]
        RejectedDueToPostOnlyImmediateMatch,

        /// <summary>
        /// Rejected due to IOC not able to match
        /// </summary>
        [StringValue("iocCancelRejected")]
        IocCancelRejected,

        /// <summary>
        /// Rejected due to IOC not able to match
        /// </summary>
        [StringValue("Rejected due to IOC not able to match")]
        RejectedDueToIocNotAbleToMatch,

        /// <summary>
        /// Rejected due to invalid TP/SL price
        /// </summary>
        [StringValue("badTriggerPxRejected")]
        BadTriggerPxRejected,

        /// <summary>
        /// Rejected due to invalid TP/SL price
        /// </summary>
        [StringValue("Rejected due to invalid TP/SL price")]
        RejectedDueToInvalidTpSlPrice,

        /// <summary>
        /// Rejected due to lack of liquidity for market order
        /// </summary>
        [StringValue("marketOrderNoLiquidityRejected")]
        MarketOrderNoLiquidityRejected,

        /// <summary>
        /// Rejected due to lack of liquidity for market order
        /// </summary>
        [StringValue("Rejected due to lack of liquidity for market order")]
        RejectedDueToLackOfLiquidityForMarketOrder,

        /// <summary>
        /// Rejected due to open interest cap
        /// </summary>
        [StringValue("positionIncreaseAtOpenInterestCapRejected")]
        PositionIncreaseAtOpenInterestCapRejected,

        /// <summary>
        /// Rejected due to open interest cap
        /// </summary>
        [StringValue("Rejected due to open interest cap")]
        RejectedDueToOpenInterestCap,

        /// <summary>
        /// Rejected due to open interest cap
        /// </summary>
        [StringValue("positionFlipAtOpenInterestCapRejected")]
        PositionFlipAtOpenInterestCapRejected,

        /// <summary>
        /// Rejected due to price too aggressive at open interest cap
        /// </summary>
        [StringValue("tooAggressiveAtOpenInterestCapRejected")]
        TooAggressiveAtOpenInterestCapRejected,

        /// <summary>
        /// Rejected due to price too aggressive at open interest cap
        /// </summary>
        [StringValue("Rejected due to price too aggressive at open interest cap")]
        RejectedDueToPriceTooAggressiveAtOpenInterestCap,

        /// <summary>
        /// Rejected due to open interest cap
        /// </summary>
        [StringValue("openInterestIncreaseRejected")]
        OpenInterestIncreaseRejected,

        /// <summary>
        /// Rejected due to insufficient spot balance
        /// </summary>
        [StringValue("insufficientSpotBalanceRejected")]
        InsufficientSpotBalanceRejected,

        /// <summary>
        /// Rejected due to insufficient spot balance
        /// </summary>
        [StringValue("Rejected due to insufficient spot balance")]
        RejectedDueToInsufficientSpotBalance,

        /// <summary>
        /// Rejected due to price too far from oracle
        /// </summary>
        [StringValue("oracleRejected")]
        OracleRejected,

        /// <summary>
        /// Rejected due to price too far from oracle
        /// </summary>
        [StringValue("Rejected due to price too far from oracle")]
        RejectedDueToPriceTooFarFromOracle,

        /// <summary>
        /// Rejected due to exceeding margin tier limit at current leverage
        /// </summary>
        [StringValue("perpMaxPositionRejected")]
        PerpMaxPositionRejected,

        /// <summary>
        /// Rejected due to exceeding margin tier limit at current leverage
        /// </summary>
        [StringValue("Rejected due to exceeding margin tier limit at current leverage")]
        RejectedDueToExceedingMarginTierLimitAtCurrentLeverage
    }
}