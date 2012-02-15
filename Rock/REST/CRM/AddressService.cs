//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the T4\Model.tt template.
//
//     Changes to this file will be lost when the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//
using System.ComponentModel.Composition;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace Rock.REST.CRM
{
	/// <summary>
	/// REST WCF service for Addresses
	/// </summary>
    [Export(typeof(IService))]
    [ExportMetadata("RouteName", "CRM/Address")]
	[AspNetCompatibilityRequirements( RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed )]
    public partial class AddressService : IAddressService, IService
    {
		/// <summary>
		/// Gets a Address object
		/// </summary>
		[WebGet( UriTemplate = "{id}" )]
        public Rock.CRM.DTO.Address Get( string id )
        {
            var currentUser = Rock.CMS.UserService.GetCurrentUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using (Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope())
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.CRM.AddressService AddressService = new Rock.CRM.AddressService();
				Rock.CRM.Address Address = AddressService.Get( int.Parse( id ) );
				if ( Address.Authorized( "View", currentUser ) )
					return Address.DataTransferObject;
				else
					throw new WebFaultException<string>( "Not Authorized to View this Address", System.Net.HttpStatusCode.Forbidden );
            }
        }
		
		/// <summary>
		/// Gets a Address object
		/// </summary>
		[WebGet( UriTemplate = "{id}/{apiKey}" )]
        public Rock.CRM.DTO.Address ApiGet( string id, string apiKey )
        {
            using (Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope())
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.CRM.AddressService AddressService = new Rock.CRM.AddressService();
					Rock.CRM.Address Address = AddressService.Get( int.Parse( id ) );
					if ( Address.Authorized( "View", user ) )
						return Address.DataTransferObject;
					else
						throw new WebFaultException<string>( "Not Authorized to View this Address", System.Net.HttpStatusCode.Forbidden );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }
		
		/// <summary>
		/// Updates a Address object
		/// </summary>
		[WebInvoke( Method = "PUT", UriTemplate = "{id}" )]
        public void UpdateAddress( string id, Rock.CRM.DTO.Address Address )
        {
            var currentUser = Rock.CMS.UserService.GetCurrentUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.CRM.AddressService AddressService = new Rock.CRM.AddressService();
				Rock.CRM.Address existingAddress = AddressService.Get( int.Parse( id ) );
				if ( existingAddress.Authorized( "Edit", currentUser ) )
				{
					uow.objectContext.Entry(existingAddress).CurrentValues.SetValues(Address);
					
					if (existingAddress.IsValid)
						AddressService.Save( existingAddress, currentUser.PersonId );
					else
						throw new WebFaultException<string>( existingAddress.ValidationResults.AsDelimited(", "), System.Net.HttpStatusCode.BadRequest );
				}
				else
					throw new WebFaultException<string>( "Not Authorized to Edit this Address", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Updates a Address object
		/// </summary>
		[WebInvoke( Method = "PUT", UriTemplate = "{id}/{apiKey}" )]
        public void ApiUpdateAddress( string id, string apiKey, Rock.CRM.DTO.Address Address )
        {
            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.CRM.AddressService AddressService = new Rock.CRM.AddressService();
					Rock.CRM.Address existingAddress = AddressService.Get( int.Parse( id ) );
					if ( existingAddress.Authorized( "Edit", user ) )
					{
						uow.objectContext.Entry(existingAddress).CurrentValues.SetValues(Address);
					
						if (existingAddress.IsValid)
							AddressService.Save( existingAddress, user.PersonId );
						else
							throw new WebFaultException<string>( existingAddress.ValidationResults.AsDelimited(", "), System.Net.HttpStatusCode.BadRequest );
					}
					else
						throw new WebFaultException<string>( "Not Authorized to Edit this Address", System.Net.HttpStatusCode.Forbidden );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Creates a new Address object
		/// </summary>
		[WebInvoke( Method = "POST", UriTemplate = "" )]
        public void CreateAddress( Rock.CRM.DTO.Address Address )
        {
            var currentUser = Rock.CMS.UserService.GetCurrentUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.CRM.AddressService AddressService = new Rock.CRM.AddressService();
				Rock.CRM.Address existingAddress = new Rock.CRM.Address();
				AddressService.Add( existingAddress, currentUser.PersonId );
				uow.objectContext.Entry(existingAddress).CurrentValues.SetValues(Address);

				if (existingAddress.IsValid)
					AddressService.Save( existingAddress, currentUser.PersonId );
				else
					throw new WebFaultException<string>( existingAddress.ValidationResults.AsDelimited(", "), System.Net.HttpStatusCode.BadRequest );
            }
        }

		/// <summary>
		/// Creates a new Address object
		/// </summary>
		[WebInvoke( Method = "POST", UriTemplate = "{apiKey}" )]
        public void ApiCreateAddress( string apiKey, Rock.CRM.DTO.Address Address )
        {
            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.CRM.AddressService AddressService = new Rock.CRM.AddressService();
					Rock.CRM.Address existingAddress = new Rock.CRM.Address();
					AddressService.Add( existingAddress, user.PersonId );
					uow.objectContext.Entry(existingAddress).CurrentValues.SetValues(Address);

					if (existingAddress.IsValid)
						AddressService.Save( existingAddress, user.PersonId );
					else
						throw new WebFaultException<string>( existingAddress.ValidationResults.AsDelimited(", "), System.Net.HttpStatusCode.BadRequest );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Deletes a Address object
		/// </summary>
		[WebInvoke( Method = "DELETE", UriTemplate = "{id}" )]
        public void DeleteAddress( string id )
        {
            var currentUser = Rock.CMS.UserService.GetCurrentUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.CRM.AddressService AddressService = new Rock.CRM.AddressService();
				Rock.CRM.Address Address = AddressService.Get( int.Parse( id ) );
				if ( Address.Authorized( "Edit", currentUser ) )
				{
					AddressService.Delete( Address, currentUser.PersonId );
					AddressService.Save( Address, currentUser.PersonId );
				}
				else
					throw new WebFaultException<string>( "Not Authorized to Edit this Address", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Deletes a Address object
		/// </summary>
		[WebInvoke( Method = "DELETE", UriTemplate = "{id}/{apiKey}" )]
        public void ApiDeleteAddress( string id, string apiKey )
        {
            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.CRM.AddressService AddressService = new Rock.CRM.AddressService();
					Rock.CRM.Address Address = AddressService.Get( int.Parse( id ) );
					if ( Address.Authorized( "Edit", user ) )
					{
						AddressService.Delete( Address, user.PersonId );
						AddressService.Save( Address, user.PersonId );
					}
					else
						throw new WebFaultException<string>( "Not Authorized to Edit this Address", System.Net.HttpStatusCode.Forbidden );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }

    }
}
