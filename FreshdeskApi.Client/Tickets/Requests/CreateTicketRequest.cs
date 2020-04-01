﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using FreshdeskApi.Client.Tickets.Models;

namespace FreshdeskApi.Client.Tickets.Requests
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class CreateTicketRequest
    {
        public CreateTicketRequest(TicketStatus status, TicketPriority priority, TicketSource source, string description, long requesterId1, string requesterName = null, long? requesterId = null, string email = null, string facebookId = null, string phoneNumber = null,
            string twitterId = null, string uniqueExternalId = null, long? responderId = null, string[] ccEmails = null,
            Dictionary<string, string> customFields = null, DateTimeOffset? dueBy = null, long? emailConfigId = null,
            DateTimeOffset? firstResponseDueBy = null, long? groupId = null, long? productId = null, string[] tags = null,
            long? companyId = null, string subject = null, string ticketType = null)
        {
            if (!requesterId.HasValue && email == null && facebookId == null && phoneNumber == null && twitterId == null && uniqueExternalId == null)
            {
                throw new ArgumentException("You must set at least one of requesterId, email, facebookId, phoneNumber, twitterId, uniqueExternalId to denote the requester");
            }

            Status = status;
            Priority = priority;
            Source = source;
            RequesterName = requesterName;
            Email = email;
            FacebookId = facebookId;
            PhoneNumber = phoneNumber;
            TwitterId = twitterId;
            UniqueExternalId = uniqueExternalId;
            Description = description;
            RequesterId = requesterId1;
            ResponderId = responderId;
            CcEmails = ccEmails;
            CustomFields = customFields;
            DueBy = dueBy;
            EmailConfigId = emailConfigId;
            FirstResponseDueBy = firstResponseDueBy;
            GroupId = groupId;
            ProductId = productId;
            Tags = tags;
            CompanyId = companyId;
            Subject = subject;
            TicketType = ticketType;
        }

        /// Name of the requester
        [JsonPropertyName("name")]
        public string RequesterName { get; }

        /// User ID of the requester. For existing contacts, the requester_id can be passed instead of the requester email.
        [JsonPropertyName("requester_id")]
        public long RequesterId { get; }

        /// Email address of the requester. If no contact exists with this email address in Freshdesk, it will be added as a new contact.
        [JsonPropertyName("email")]
        public string Email { get; }

        /// Facebook ID of the requester. If no contact exists with this facebook_id, then a new contact will be created.
        [JsonPropertyName("facebook_id ")]
        public string FacebookId { get; }

        /// Phone number of the requester. If no contact exists with this phone number in Freshdesk, it will be added as a new contact. If the phone number is set and the email address is not, then the name attribute is mandatory.
        [JsonPropertyName("phone")]
        public string PhoneNumber { get; }

        /// Twitter handle of the requester. If no contact exists with this handle in Freshdesk, it will be added as a new contact.
        [JsonPropertyName("twitter_id ")]
        public string TwitterId { get; }

        /// External ID of the requester. If no contact exists with this external ID in Freshdesk, they will be added as a new contact.
        [JsonPropertyName("unique_external_id ")]
        public string UniqueExternalId { get; }

        /// Subject of the ticket. The default Value is null.
        [JsonPropertyName("subject")]
        public string Subject { get; }

        /// Helps categorize the ticket according to the different kinds of issues your support team deals with. The default Value is null.
        [JsonPropertyName("type")]
        public string TicketType { get; }

        /// Status of the ticket. The default Value is 2.
        [JsonPropertyName("status")]
        public TicketStatus Status { get; }

        /// Priority of the ticket. The default value is 1.
        [JsonPropertyName("priority")]
        public TicketPriority Priority { get; }

        /// HTML content of the ticket.
        [JsonPropertyName("description")]
        public string Description { get; }

        /// ID of the agent to whom the ticket has been assigned
        [JsonPropertyName("responder_id")]
        public long? ResponderId { get; }

        /// Email address added in the 'cc' field of the incoming ticket email
        [JsonPropertyName("cc_emails")]
        public string[] CcEmails { get; }

        /// Key value pairs containing the names and values of custom fields.
        [JsonPropertyName("custom_fields")]
        public Dictionary<string, string> CustomFields { get; }

        /// Timestamp that denotes when the ticket is due to be resolved
        [JsonPropertyName("due_by")]
        public DateTimeOffset? DueBy { get; }

        /// ID of email config which is used for this ticket. (i.e., support@yourcompany.com/sales@yourcompany.com)
        /// If product_id is given and email_config_id is not given, product's primary email_config_id will be set
        [JsonPropertyName("email_config_id")]
        public long? EmailConfigId { get; }

        /// Timestamp that denotes when the first response is due
        [JsonPropertyName("fr_due_by")]
        public DateTimeOffset? FirstResponseDueBy { get; }

        /// ID of the group to which the ticket has been assigned. The default value is the ID of the group that is associated with the given email_config_id
        [JsonPropertyName("group_id")]
        public long? GroupId { get; }

        /// ID of the product to which the ticket is associated.
        /// It will be ignored if the email_config_id attribute is set in the request.
        [JsonPropertyName("product_id")]
        public long? ProductId { get; }

        /// The channel through which the ticket was created. The default value is 2.
        [JsonPropertyName("source")]
        public TicketSource Source { get; }

        /// Tags that have been associated with the ticket
        [JsonPropertyName("tags")]
        public string[] Tags { get; }

        /// Company ID of the requester. This attribute can only be set if the Multiple Companies feature is enabled (Estate plan and above)
        [JsonPropertyName("company_id")]
        public long? CompanyId { get; }

        public override string ToString()
        {
            return $"{nameof(RequesterName)}: {RequesterName}, {nameof(RequesterId)}: {RequesterId}, {nameof(Email)}: {Email}, {nameof(FacebookId)}: {FacebookId}, {nameof(PhoneNumber)}: {PhoneNumber}, {nameof(TwitterId)}: {TwitterId}, {nameof(UniqueExternalId)}: {UniqueExternalId}, {nameof(Subject)}: {Subject}, {nameof(TicketType)}: {TicketType}, {nameof(Status)}: {Status}, {nameof(Priority)}: {Priority}, {nameof(Description)}: {Description}, {nameof(ResponderId)}: {ResponderId}, {nameof(CcEmails)}: {CcEmails}, {nameof(CustomFields)}: {CustomFields}, {nameof(DueBy)}: {DueBy}, {nameof(EmailConfigId)}: {EmailConfigId}, {nameof(FirstResponseDueBy)}: {FirstResponseDueBy}, {nameof(GroupId)}: {GroupId}, {nameof(ProductId)}: {ProductId}, {nameof(Source)}: {Source}, {nameof(Tags)}: {Tags}, {nameof(CompanyId)}: {CompanyId}";
        }
    }
}
