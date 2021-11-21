$BlockIds = @(
'LargeBlockArmorRoundSlope'
'LargeBlockArmorRoundCorner'
'LargeBlockArmorRoundCornerInv'
'LargeHeavyBlockArmorRoundSlope'
'LargeHeavyBlockArmorRoundCorner'
'LargeHeavyBlockArmorRoundCornerInv'
'SmallBlockArmorRoundSlope'
'SmallBlockArmorRoundCorner'
'SmallBlockArmorRoundCornerInv'
'SmallHeavyBlockArmorRoundSlope'
'SmallHeavyBlockArmorRoundCorner'
'SmallHeavyBlockArmorRoundCornerInv'
'LargeBlockArmorSlope2Base'
'LargeBlockArmorSlope2Tip'
'LargeBlockArmorCorner2Base'
'LargeBlockArmorCorner2Tip'
'LargeBlockArmorInvCorner2Base'
'LargeBlockArmorInvCorner2Tip'
'LargeHeavyBlockArmorSlope2Base'
'LargeHeavyBlockArmorSlope2Tip'
'LargeHeavyBlockArmorCorner2Base'
'LargeHeavyBlockArmorCorner2Tip'
'LargeHeavyBlockArmorInvCorner2Base'
'LargeHeavyBlockArmorInvCorner2Tip'
'SmallBlockArmorSlope2Base'
'SmallBlockArmorSlope2Tip'
'SmallBlockArmorCorner2Base'
'SmallBlockArmorCorner2Tip'
'SmallBlockArmorInvCorner2Base'
'SmallBlockArmorInvCorner2Tip'
'SmallHeavyBlockArmorSlope2Base'
'SmallHeavyBlockArmorSlope2Tip'
'SmallHeavyBlockArmorCorner2Base'
'SmallHeavyBlockArmorCorner2Tip'
'SmallHeavyBlockArmorInvCorner2Base'
'SmallHeavyBlockArmorInvCorner2Tip'


);
$Builder = "CubeBlocks"
$Gruppe = "Armor"

$TextBlock = '
    <ResearchBlock xsi:type="ResearchBlock">                                    <!--XXXXXXXX-->
      <Id Type="MyObjectBuilder_yyyyy" Subtype="XXXXXXXX" />
      <UnlockedByGroups>
        <GroupSubtype>zzzzz</GroupSubtype>
      </UnlockedByGroups>
    </ResearchBlock>'

foreach ($Block in $BlockIds)
{
$temp = $TextBlock -replace "XXXXXXXX", $Block
$temp = $temp -replace "yyyyy", $Builder
$temp = $temp -replace "zzzzz", $Gruppe
Write-Host $temp

}
