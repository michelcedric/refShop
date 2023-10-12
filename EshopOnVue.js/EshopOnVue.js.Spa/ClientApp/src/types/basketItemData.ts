import CatalogItemData from "./CatalogItemData";
import { v4 as uuid } from 'uuid';
import Size from "./CatalogItemDetailsData";

export default class BasketItemData {
    id: string;
    catalogItem: CatalogItemData;
    size: Size | undefined;
    quantity: number;
    constructor(catalogItem: CatalogItemData, size: Size | undefined, quantity: number) {
        this.id = uuid();
        this.catalogItem = catalogItem;
        this.quantity = quantity;
        this.size = size;
    }
}
