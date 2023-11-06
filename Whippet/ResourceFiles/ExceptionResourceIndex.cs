using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.ResourceFiles
{
    /// <summary>
    /// Provides an index of all shared exceptions available in Whippet. This class cannot be inherited.
    /// </summary>
    public static class ExceptionResourceIndex
    {
        public const string EmptyGuidException = nameof(EmptyGuidException);
        public const string EventNotSupportedException = nameof(EventNotSupportedException);
        public const string NumericValueRequiredException = nameof(NumericValueRequiredException);
        public const string ArgumentExceedsMaximumLengthWithValueException = nameof(ArgumentExceedsMaximumLengthWithValueException);
        public const string ArgumentExceedsMaximumLengthException = nameof(ArgumentExceedsMaximumLengthException);
        public const string InvalidTypeException = nameof(InvalidTypeException);
        public const string CommandHandlerNotFoundException = nameof(CommandHandlerNotFoundException);
        public const string TreeIndexCannotExceedChildrenCountException = nameof(TreeIndexCannotExceedChildrenCountException);
        public const string TreeNodeCircularReferenceException = nameof(TreeNodeCircularReferenceException);
        public const string TreeNodeParentAlreadyAssignedException = nameof(TreeNodeParentAlreadyAssignedException);
        public const string TreeNodeDisconnectException = nameof(TreeNodeDisconnectException);
        public const string TreeNodeDuplicateKeysDetectedException = nameof(TreeNodeDuplicateKeysDetectedException);
        public const string TreeNodeDuplicateKeysDetectedException_NoKey = nameof(TreeNodeDuplicateKeysDetectedException_NoKey);
        public const string TreeNodeSameIdAndParentIdException = nameof(TreeNodeSameIdAndParentIdException);
        public const string TreeNodeSameIdAndParentIdException_NoId = nameof(TreeNodeSameIdAndParentIdException_NoId);
        public const string TreeNodeParentIdNotFoundException = nameof(TreeNodeParentIdNotFoundException);
        public const string TreeNodeParentIdNotFoundException_NoId = nameof(TreeNodeParentIdNotFoundException_NoId);
        public const string NullObjectException = nameof(NullObjectException);
        public const string CollectionRestrictionViolationException = nameof(CollectionRestrictionViolationException);
        public const string NoWhippetSettingGroupsExistForApplicationException = nameof(NoWhippetSettingGroupsExistForApplicationException);
        public const string MultipleParameterValuesException = nameof(MultipleParameterValuesException);
        public const string ConcreteClassTypeRequiredException = nameof(ConcreteClassTypeRequiredException);
        public const string MissingParameterException = nameof(MissingParameterException);
        public const string DuplicateEntityException = nameof(DuplicateEntityException);
    }
}
