export default interface Size {
  id: string,
  description: string
}

export default interface CatalogItemDetailsData {
  id: string,
  name: string,
  price: number,
  memberPrice: number,
  pictureUri: string
  sizes: Size[]
}