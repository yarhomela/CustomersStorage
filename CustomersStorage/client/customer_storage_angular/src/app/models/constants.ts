import { CustomerViewModel } from "./customer/customer-view-model";
import { CustomersSampleRequestModel } from "./customer/customers-sample-request-model";
import { CustomerOrderSettingsEnum } from "./enums/customer-order-settings.enum";

export const customersListName = 'customerList';
export const customerModel = {
    customerId: 0,
    name: '',
    companyName: '',
    phone: '',
    email: ''
} as CustomerViewModel;
export const customersRequestModel = {
    searchWord: '',
    sortingBy: CustomerOrderSettingsEnum.Name,
    byAscending: true,
    page: 1,
    pageSize: 10,
} as CustomersSampleRequestModel;