import { CustomerViewModel } from "./customer-view-model";

export interface CustomersSampleResponseModel {
    customers: CustomerViewModel[];
    pagesCount: number;
}