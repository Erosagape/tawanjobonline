@ModelType IEnumerable(Of jobonline.CCompany)
@Code
ViewData("Title") = "Companies"
End Code
<p>
    @Html.ActionLink("Create New", "Company", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.CustCode)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Branch)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CustGroup)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.TaxNumber)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Title)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.NameThai)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.NameEng)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.TAddress1)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.TAddress2)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.EAddress1)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.EAddress2)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Phone)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.FaxNumber)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.LoginName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.LoginPassword)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.ManagerCode)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CSCodeIM)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CSCodeEX)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CSCodeOT)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.GLAccountCode)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CustType)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.BillToCustCode)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.BillToBranch)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.UsedLanguage)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.LevelGrade)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.TermOfPayment)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.BillCondition)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CreditLimit)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.MapText)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.MapFileName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CmpType)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CmpLevelExp)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CmpLevelImp)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Is19bis)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.MgrSeq)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.LevelNoExp)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.LevelNoImp)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.LnNO)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.AdjTaxCode)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.BkAuthorNo)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.BkAuthorCnn)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.LtdPsWkName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.ConsStatus)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CommLevel)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.DutyLimit)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CommRate)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.TAddress)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.TDistrict)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.TSubProvince)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.TProvince)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.TPostCode)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.DMailAddress)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.PrivilegeOption)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.GoldCardNO)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CustomsBrokerSeq)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.ISCustomerSign)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.ISCustomerSignInv)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.ISCustomerSignDec)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.ISCustomerSignECon)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.IsShippingCannotSign)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.ExportCode)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Code19BIS)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.WEB_SITE)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.CustCode)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Branch)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.CustGroup)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.TaxNumber)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Title)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.NameThai)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.NameEng)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.TAddress1)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.TAddress2)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.EAddress1)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.EAddress2)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Phone)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.FaxNumber)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.LoginName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.LoginPassword)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ManagerCode)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.CSCodeIM)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.CSCodeEX)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.CSCodeOT)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.GLAccountCode)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.CustType)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.BillToCustCode)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.BillToBranch)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.UsedLanguage)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.LevelGrade)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.TermOfPayment)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.BillCondition)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.CreditLimit)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.MapText)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.MapFileName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.CmpType)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.CmpLevelExp)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.CmpLevelImp)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Is19bis)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.MgrSeq)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.LevelNoExp)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.LevelNoImp)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.LnNO)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.AdjTaxCode)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.BkAuthorNo)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.BkAuthorCnn)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.LtdPsWkName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ConsStatus)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.CommLevel)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.DutyLimit)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.CommRate)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.TAddress)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.TDistrict)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.TSubProvince)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.TProvince)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.TPostCode)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.DMailAddress)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.PrivilegeOption)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.GoldCardNO)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.CustomsBrokerSeq)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ISCustomerSign)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ISCustomerSignInv)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ISCustomerSignDec)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ISCustomerSignECon)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.IsShippingCannotSign)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ExportCode)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Code19BIS)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.WEB_SITE)
        </td>
        <td>
            @*@Html.ActionLink("Edit", "Edit", New With {.id = item.PrimaryKey}) |
            @Html.ActionLink("Details", "Details", New With {.id = item.PrimaryKey}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.PrimaryKey})*@
        </td>
    </tr>
Next

</table>
