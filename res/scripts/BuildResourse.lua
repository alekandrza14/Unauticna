-- defines a Jump function
function Build (patrn)
for i=1,8,1 do


        vec3.Add(math.random(-10,10));
        vec3.Add(math.random(-1,6));
        vec3.Add(math.random(-10,10));
   
end

return vec3;
end
local c = 0;
function Item (patrn)

for i=1,8,1 do
c = math.random(1,8);
if c >= 0 and c <= 1 then
ditem.Add("u");
elseif c >= 1 and c <= 2  then
ditem.Add("c");
elseif c >= 2 and c <= 3  then
ditem.Add("ti");
elseif c >= 3 and c <= 4  then
ditem.Add("cr");
elseif c >= 4 and c <= 5  then
ditem.Add("fr");
elseif c >= 5 and c <= 6  then
ditem.Add("si");
elseif c >= 6 and c <= 7  then
ditem.Add("he");
elseif c >= 7 and c <= 8  then
ditem.Add("Ṳx");
end

end


return ditem;
end