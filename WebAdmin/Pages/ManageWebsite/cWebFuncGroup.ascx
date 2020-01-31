<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cWebFuncGroup.ascx.cs" Inherits="Pages_ManageWebsite_cWebFuncGroup" %>


<!-- Content Header (Page header) -->
<section class="content-header">
    <h1>
        <i class="fa fa-list"></i>
        Phân quyền người dùng
    </h1>
    <ol class="toolbar">
        <%--<li><button runat="server" id="btCreate" onserverclick="New_Click" class="btn btn-info btn-sm">
            <i class="fa fa-plus-square"></i>
            <span>Tạo mới</span>
            </button>
        </li>
        <li><button runat="server" id="btClone" onserverclick="Clone_Click" class="btn btn-info btn-sm">
            <i class="fa fa-copy"></i>
            <span>Sao chép</span>
            </button>
       </li>
        <li>
            <button runat="server" id="btDelete" onserverclick="Delete_Click" class="btn btn-info btn-sm">
                <i class="fa fa-trash-o"></i>
                <span>Xóa</span>
            </button>
        </li>--%>
    </ol>
</section>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
<ContentTemplate>
<div runat="server" id="message_box">    
</div>



<section class="content">
    <div class="row">
        <div class="col-xs-12">
            <div class="box">
                <div class="box-body table-responsive">
                    <div id="example1_wrapper" class="dataTables_wrapper form-inline" role="grid">
                        <div class="row">
                            <div class="col-xs-6">
                                <div id="example1_length" class="dataTables_length">
                                    <label>
                                        <asp:DropDownList runat="server" ID="ddlRGroup" DataTextField="GroupName" DataValueField="GroupID"
                                            AutoPostBack="True" onselectedindexchanged="ddlRGroup_SelectedIndexChanged" 
                                            class="form-control" style="max-width: 200px;">
                                        </asp:DropDownList>
                                    </label>
                                    <label>
                                        <button id="Button1" runat="server" onserverclick="cSave_Click" class="btn btn-info btn-sm">
                                            <i class="fa fa-trash-o"></i>
                                            <span>Lưu</span>
                                        </button>
                                    </label>
                                </div>
                            </div>
                            <div class="col-xs-6">
                                <%--<div class="dataTables_filter" id="example1_filter">
                                    <label>Search: <input type="text" aria-controls="example1"></label>
                                </div>--%>
                            </div>
                        </div>
                        <telerik:RadTreeView runat="server" ID="RadTreeView1" DataFieldID="FuncID" DataFieldParentID="ParentID" 
                        TriStateCheckBoxes="true" CheckBoxes="true" CheckChildNodes="true" Skin="Metro">
                            <DataBindings>                
                                <telerik:RadTreeNodeBinding TextField="VNName" ValueField="ID" Expanded="true" CheckedField="pView"></telerik:RadTreeNodeBinding>
                            </DataBindings>
                        </telerik:RadTreeView>
                    </div>
                </div><!-- /.box-body -->
            </div><!-- /.box -->
        </div>
    </div>
</section>
</ContentTemplate>
</asp:UpdatePanel>