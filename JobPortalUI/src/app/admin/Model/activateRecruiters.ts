export interface IActivateRecruiter {
  companyID?: number,
  companyName?: string,
  address?: string,
  loginID?: string,
  password?: string,
  regDate?: Date,
  recSignedPDF?: boolean,
  bdid?: number,
  recRegDate?: Date,
  zoneID?: number,
  coordinatorID?: number,
  campusID?: number,
  processCoordinatorID?: number,
  crEmailID?: string,
  [table: string]:any,
  

}

export interface IcontactDetails {
  contactID?: number,
  companyID?: number,
  title?: string,
  firstName?: string,
  lastName?: string,
  designation?: string,
  officePh?: string,
  officeExt?: string,
  mobile?: string,
  resPh?: string,
  fax?: string,
  emailID?: string,
  sendMail?: boolean,
  mobileCCode?: string,
  officeCCode?: string,
  officeACode?: string,
  faxCCode?: string,
  faxACode?: string,
  contactSequence?: number
}

export interface IcompanyDetails {
  companyID?: number,
  companyName?: string,
  loginID?: string,
  password?: string,
  address1?: string,
  address2?: string,
  city?: string,
  country?: string,
  website?: string,
  industryGrpID?: number,
  industry?: string,
  regDate?: Date,
  status?: boolean,
  bdid?: string,
  lastLoginDate?: string,
  recSignedPDF?: boolean,
  approvedDate?: string,
  updatedDate?: Date,
  zipCode?: number,
  disabled?: boolean,
  no_interviewers?: string,
  tieringDay?: string,
  acceptPolicies?: boolean,
  acceptedDateTime?: Date,
  internationalDomestic?: string,
  oldNewCompany?: string,
  zoneID?: string,
  disableMailer?: string,
  invoiceStatus?: string,
  compYear?: string,
  compID?: string,
  updatedBy?: string,
  approvedBy?: string,
  coordinator?: string,
  statusRemarks?: string,
  campusID?: string,
  coordinatorID?: string,
  placementDate?: string,
  toStagingServer?: string,
  grade?: string,
  selectionType?: boolean,
  pan?: string,
  tan?: string,
  st?: string,
  panDoc?: string,
  tanDoc?: string,
  stDoc?: string,
  sapid?: string,
  panDocument?: string,
  tanDocument?: string,
  stDocument?: string,
  salesOrderNo?: string,
  proformaInvoiceNo?: string,
  finalInvoiceNo?: string,
  invoiceRaisedStatus?: string,
  amountReceived?: string,
  dateOfReceipt?: string,
  companyCategoryID?: string,
  processCoordinatorID?: string,
  companyFilePath?: string,
  expectedAO?: string,
  actualAO?: string,
  tutionWaiver?: boolean,
  industryGroup?: string,
  bd?: string,
  coordinatorName?: string
}