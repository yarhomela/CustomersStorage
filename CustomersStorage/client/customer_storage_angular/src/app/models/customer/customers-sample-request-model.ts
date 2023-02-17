import { CustomerOrderSettingsEnum } from "../enums/customer-order-settings.enum";

export interface CustomersSampleRequestModel {
    searchWord?: string;
    sortingBy: CustomerOrderSettingsEnum;
    byAscending: boolean;
    page: number;
    pageSize: number;
}